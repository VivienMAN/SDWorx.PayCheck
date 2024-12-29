using Microsoft.AspNetCore.Components;
using Radzen;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Blazorise;
using Microsoft.JSInterop;
using Radzen.Blazor;

namespace SDWorx.PayCheck.Components.Pages;

public class HomeBase : ComponentBase
{
    [Inject] protected DialogService DialogService { get; set; }
    [Inject] protected NavigationManager NavigationManager { get; set; }
    [Inject] protected IJSRuntime JSRuntime { get; set; }

    protected bool File1Uploaded { get; set; } = false;
    protected bool File2Uploaded { get; set; } = false;
    private MemoryStream imemFileMemoryStream = new MemoryStream();
    private MemoryStream csvFileMemoryStream = new MemoryStream();
    protected DateTime? Date1 { get; set; }

    protected DateTime? Date2
    {
        get => _date2;
        set
        {
            if (value == null || value == default)
            {
                _date2 = null;
            }
            else
            {
                _date2 = new DateTime(value.Value.Year, value.Value.Month, 1);
            }
        }
    }

    private DateTime? _date2;

    private const string ExcelFilePattern = @"^IRETAM-(\d{6})\.xlsx$";
    private const string CsvFilePattern = @"^IRETAM-(\d{6})-ID\.csv$";

    protected DateTime? Date3
    {
        get
        {
            if (Date2 == default)
            {
                return null;
            }

            return new DateTime(Date2.Value.Year, Date2.Value.Month,
                DateTime.DaysInMonth(Date2.Value.Year, Date2.Value.Month));
        }

        set { }
    }

    protected string ImageBase64 =
        "iVBORw0KGgoAAAANSUhEUgAAAhwAAADACAMAAAB4Q0ozAAAAP1BMVEUAAACdg3lyeYnuSCx0eoqIjpz6rgfmADp+hJOJjptVXXL5rgflADqKj5t4hKGKj5v4rQeJjpp3g6BVXXHkADqfjsGaAAAAEHRSTlMAGjdEVnR7iYyys8HO1dbwW9NO6gAADlZJREFUeNrtnd2WnDgShEmVNE6pLTNs+f2fdXd9jt1QUirIVpXH00Tc2Q31Q34oQ4Gglt+tt78tvS3URYXh+IsH5+KSvwkHZehmwyE8OhfXXzYcPDi0HPSjlCFaDuoDfvTGo0PLQT9KGXDQclCMwCj6UYoRGMUIjKIfpehHKUZgFP0oRctB0XLQclCMwKhzEloOytKNERhFP0rRj1LPEyMwin6UouWgnggHLQdFP0q5RctBMQKj6EcpWg7qd8DBCIxiBEZ5daPloBiBUfSjFCMw6vUSRmAUIzCKfpRiBEb9BtFyUIzAKFoO6tNFYFJ2Yr7yx8PxW0sU7jsFloURGOGgHyUc9KOEgxEY4fjXSm6W3BEY4fhs+vLdkvj86BvhuBAcTj/6F+G4Dhxf+36UcFxIX004vBEY4bgOHF+8fpRwfDp9N+Fw+lHC8ekkJhw3p+UgHJ9Ot2fBcSMcF4JDfH50IRxXjzlsy0E4Lhtz4AiMcFwWDmw5CMdlYw4cgREOwmFpIRxXzcBwBEY4LpuBYT9KOC6bgWE/Sjgum4Fhy0E4rpqB4QiMcFw95hDbchCOy8KBLQfhuGrMgeEQwnFZOLAfJRxXysBur/CjIoTjs2Vg8xFY1FJ+FrKUuKsl3q/82KnZ64+EIyTNdd3+r7VmTTJTm/Tjpdaa/tiYY96PipZ7oxIXJIml3QvCkfZCpdRfCpDSd0WzmOv2qDWjL5r0lw5vWLef0p/g7RUwp3vJU+F4luUI5W6oyPKB/VTGcORtJ3AEddsVYKx92WOXnrwZWvPwY9Ttl+T929et+WxSt53qAnTYOr98JvvmtxxioQHwCIP9dAhH3HZKoOKnj3XYdpKlUarbSCM8cvvCotte2n4IjLMe+JSnwzEfgcU70NJXuY9UwgAOOX/ChPODTBq+aKgbUpbzcMjDy2lTcPyJA9h0Co4vHj96M2sMVIx5CFJs4ej2lRWcXKcHmTzYUvJ2QmvCLx2ObLRjBGws/S315TGHPwIruMjGcAMVbTgSPGX8h1qMroKHDTyM6cOnlXVr4fA2lgS+2iQc85ZD71DWbljRhEPAeLA/0sBJdI1MNcqAVeUMHC1r2rwbQl/AZrMZmD8C8xe5mMMNVjBzjgrO1qYqmCO1tsNsQF+ox2lQ3hqpe7TL4ItNZmAy60flEQSNQSTEqKXpKoiN8kOPkccBDqvooKs0HOFN5VjZRlVTijGlXDt0hGEHiLsxyoBDjL/YxOaXZ2B+P1oGk9agVleJLRga3ncr+z8c4LDaRQRdpeEIbVqH48Yh8pJUT3SWdDjHqwGHp7HICkarWTg8fhS7ytANMgqep5RwLv8IVmCl2LNhjpIxSCc4X431kY4xHMdXXGvOta5qt4wKm0p86WoO7EfhwCH9nCuiVnSPvd0gHPmUU69gNmG8YDDHnjWecDabjuDYc52NyFtW0Fiiu6nMw+GyHNKpHFYxAlTsdIN5dAQaehyKGLDVTsfAI1S0/67xTKYax41FVvCh5jOwScuhMOnCAUdx5K7BrHtEraLCKV/sn6l6ctwJ65FBseGolnHFjQVcXHpdzOGPwErbG7BMNjAdwTw+irpKhJtq92gH4CUauIy3iSAQcTaWOBuNYjhu5+F4Q3V2Dxx4vNExHAlXTd6byYoKXLuvVo3hAHcWAXCYoIHG0jaVF60Dm/OjgqoMgIJIlQYOkHab9cq7cSZAd6KwQLgRbNqptM8nqMmSmp8q9RUnMzB/BBYAHGDgwL1IhnAsFQaEuTd9TPC8D/jKFm4EmzRweH1CNSLQYEej3/7Tlz/mmPSjEcCBBgO8kw7hUOQUZVeKAIbh3JvQBLup4MaSDDhg2m2/Pb50oAYc4oXj62wEBhsEyL9kAZIhHAHNUOM+FwUtqDtCZGc9V7MRRMNw4MbSYqADYpMBR5yIOaDlgJUO0wMHdh1hUIswGg3yodAJuL/YdTXrYgun3hHmtLixxBMXDoIBh87HHN6rbu6+Mqq1P59XcF4fxoI0bEHaoyC5J4zm9DPiJA43lhYYbWpiwJGn4RDbcuBSR29XKdM0RaP3Nn8Ox+Msw1M046TJn1zFzQWawae16gQ70m8TMQfyo+Ie9LHBVHcfCgOjsI4q9XBWtxwL6CrAJRgMCAwtsOrDfgJ6aYbTFT8cOALDGWb0lVrm4cijA/WYe+XBKJMayvASd9xXogEH6ip23oVbqRpwBGcGJtN3JQzWfOHt/blIGA26ap/F+rDxOmoHGaxTdfQVBRdR/Y0lBTSYRQOO6MzA3H4UB9zRYznm4ZDRodKHwobBZGHt/S2jRUJ4zS8Yhdy8rRXkLqYj1YmYA/lRQ+a9arjSOgGHsbLPKPjabKyDSYF0W0SdmF7s4GjY9DYWjBiYrjjg8Edg+OaTEk750fAMOJJ9yEODgpp9RXtDvnykE4jhSKO7RRlggU+Epyv+mSz2o7h4+P7pMhmphuGJqlbBY3uQ7as0CVzB8M4uMBxYGaxx9wfofjjegOXw3NNU5LVw4Bth19YuWCAJPtnjhwoZwbo1V2MBGStypGEODmA5UK/AeNyfD4daxzwMQ61qNaeMb6qbh2PxKozWqp8M0NNEzIEiMNxZMB6HP07AYfTj1Kcm9cotRkHTLByK4VgXt9SxUghPV/xwYMvhf5JCfDkcy2pYtNrhQAyQ1i40CXUCXMYE4XBYGcwqdqT+DAxHYEgKBo8XwpH7Bz2AleS52bbZWD8ER3oNHBl0FW+AjjOweT+KH98iL4Yj9c+nhO5Pki4FCcDxT7WVBBeS4SUd4ow5/BGYv7eE18IhfdNRm8Noh6S1YeBPg0NWuDwZO9I4AcfNEYG5Ro/wdDjwxXYxjmI1tm02fuVsZZ1xHLixCJyu+Gey2I9ixR4f5flTWXxB1UivdLjtlp4ER7tXmoEjbR0FryPNbjjmLQfuLuXJcODrIuaNCKFzcNVa5Y8yJ3ySy1PgCFtPVZyO9JsDjttEBObsLuFZCSkqR2yXcpgzX33fv9l4Ij5fm7RrGo5qPWDKGaB/POYQEIHN4FEaOKYuvOHnjAazqNqQIGaoDiqBz/IK4PBb3AN6cSJAB3DInOVwhaahA0echsOOKdScZbQrSZPZxps6e+1BBnC4ccunbqSR09MVEHNgOLDlwINH6VS6TMNhB5y1rWm7cXq0JyuyD/6VYPNwyHHJSm7gmwjQBc9k5/0ovh3JvxLM6ESgIPGhIaTBxrlxIWBW6vYH0QsHfjaqwMaCpyv+mOMJlgPf29b7v3k44mauFpXBxmszfwG3BfjX+rjhwI+/TCcai4LpCoTjy0wE5i5r7PyfTt63YqdYef9Pu6+EZtkxWvLnvTEewOGMRiN4FD50pOKIOWb8KJYgOIrb2QY8lh/rn4bjtDb/BD3Ce8fbPBz5CEKbekRPgB7m4Zi3HC0Jims9cdtU2ox722Q4UNcjABHfx+x83soMHPaqAcWNBQTo3gzsDURgk3CUXpcoTltrwhGOYVUazz+Pw8yoZMFwEO7nrGM4cFNJ/atw2eFI1ZGBTUVgWIpiMDx0FABH/3paNrtKG60H6yij/o4HjgTg8LFWrbeJzgDdn4HdgOWYhUO7c5iyTDzZx849zz4LatP9PyK84hVdF9ZXmYTDvvKXjfeBSzr8GRi2HPNtJfbHgjjxTDAz9wxnnyK31f1xxuWuroWeukzCEdpXw40FT1f8Gdjbq+EwgnVxPk0QzxLiksZd5QhENQ4xrDdyKKvMwlFHr7ZXcgXo/gzsBZZD+hDcAR3gOaSw3un9oAocroOAniHr6cYS1lHFMBx4SRlqLNiRJk8Ghv3ocyxHMUtexPUEY2wF8wINpPRuWhcLJIMOgFFdJuBAt+XjxpJBgA5jjnk/KnJy4FDw6HPHs89RvdeIusq+l6QBSa57AgRsB+Bw/GAGbiw4QMcxx7wf1buK+6JIuD8oDq/qFgBHM86irnKMzAFJxyrZG8YVrPD0wpGN9wSPVkaO1A8HjsBsAAw8ZBCUF3hbvujOlBgYwWWW+dzlMUwS/nlQyeC9ARygqVRsf7M/QMcxB/aj2HKWKPB5UDYd7UuEctgVwGHWO3kW3lXHrYhrkofCr2B5pxsOWUErg41lMF3BcLR+FFsOG4Gyr27Qx9K3ULUqRWOMquVx12LAgeotnuXcyfUEhFXj7tuu6OkIGA7cVHBj8QfoYCY7ZzlK/xf8GolFFZYYcODzO7vWcwuoVauas+Zc8ZMzMBz+34vFv/aheLoir4RD7kBNSd10hMWAA9c7oYAJFADQgX5XFsMx/yPkOvjCCUxXYMyB/ajAroIVwb6AjQYOS6tnLFCDJLQ9VpbFAQcmV08jHs44UnHD8bEIrDjYaBTOsXF8Gz1/dmdwcoL0AsxVGwHMABxwNZm/sQiYroCZ7HQE5mcD31nbpmMYDny9HK+8wJK8YdWwTMGBV3rhxoIDdAzHvB+NoLz4V7pG0s4AVbxre20pHLr9g0c1KgnhwGtI/I0lW9MVDIdMRGBGIgEeKugbPEroMVQc6y2BQntQsVIdoZGWZQYOuAgQD5fV4UhhzIH9KJJoAfUFdIFdPXAkMBrjxxBiRaO5rBl8WwwHXuWFnVbCAboDDhiBYcmuvbShmH/vx10l/lIAqL1rgZLwS7I4JKkJN6pGz9uFcHa7sGAFawfpy5uBiaXlrCRo+SnVuPgUYvmffmRooP5/iCQmzTnXnLMmwNYfK7FnstTVdSMcFOGgHEIxB48N4SAclBsO4bG5qnDMwUNDWXB85aGhvhMOihkYxZiDeppunMlSjDkoxhzUE+FgzEEx5qAIB/U8cSZLMQOjmIFRzMAoZmAUMzCKGRjFmIMiHBQzMIoZGOGgGHNQhINizEEx5qD+CTg4k6UYc1B+ODiTpZiBUczAKMYc1Ot1Y8xBMeagCAfFDIya0X8BQ5dvbHsaWsIAAAAASUVORK5CYII=";

    protected void OnLaunchClick()
    {
        // Logique à exécuter lorsque le bouton "Launch" est cliqué
        Console.WriteLine("Bouton Launch cliqué !");
    }

    protected void Reset()
    {
        Date1 = null;
        Date2 = null;
        Date3 = null;
        ResetImenExel();
        ResetImenCsv();
        Console.WriteLine("Bouton Reset cliqué !");
    }

    protected void ResetImenExel()
    {
        File1Uploaded = false;
        imemFileMemoryStream = new MemoryStream();
    }

    protected void ResetImenCsv()
    {
        File2Uploaded = false;
        csvFileMemoryStream = new MemoryStream();
    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        // Ouvrir le composant PasswordDialog dans une boîte de dialogue
        var result = await DialogService.OpenAsync<PasswordDialog>(
            "Authentification",
            new Dictionary<string, object>(), // Pas de paramètres nécessaires pour ce composant
            new DialogOptions() { CloseDialogOnOverlayClick = false, Width = "600px", Height = "300px" }
        );

        // Vérification du mot de passe
        if (result != "1234")
        {
            // Si le mot de passe est invalide, on ferme l'application (onglet)
            Application.Current?.Quit();
        }
    }

    protected async Task OnChanged(FileChangedEventArgs e)
    {
        try
        {
            var file = e.Files.FirstOrDefault();
            if (file == null)
            {
                return;
            }


            string fileExtension = Path.GetExtension(file.Name).ToLower();
            if (fileExtension == ".xlsx" && Regex.IsMatch(file.Name, ExcelFilePattern))
            {
                await file.OpenReadStream(long.MaxValue).CopyToAsync(imemFileMemoryStream);
                Console.WriteLine("IMEM.xlsx file uploaded successfully.");
                File1Uploaded = true;
            }
            else if (fileExtension == ".csv" && Regex.IsMatch(file.Name, CsvFilePattern))
            {
                await file.OpenReadStream(long.MaxValue).CopyToAsync(csvFileMemoryStream);
                Console.WriteLine("CSV file uploaded successfully.");
                File2Uploaded = true;
            }
            else
            {
                Console.WriteLine("Invalid file type or name.");
            }
        }
        catch (Exception exc)
        {
            Console.WriteLine(exc.Message);
        }
        finally
        {
            this.StateHasChanged();
        }
    }

    protected void OnError(UploadErrorEventArgs args, string name)
    {
        Console.WriteLine($"{args.Message}");
    }
}