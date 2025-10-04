using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MeuTccMvc.Models.Enum;
public static class EnumExtensions
{
    public static string GetDisplayName(this System.Enum enumValue)
    {
        return enumValue.GetType()
                        .GetMember(enumValue.ToString())[0]
                        .GetCustomAttribute<DisplayAttribute>()?
                        .Name ?? enumValue.ToString();
    }
}