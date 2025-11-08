namespace DotnetLab202203.Models;
using System.ComponentModel.DataAnnotations;
public class Starship
{
    [StringLength(50, ErrorMessage = "名前は50文字以下で入力してください。")]
    public string Name { get; set; } = string.Empty;
    [StringLength(50, ErrorMessage = "モデルは50文字以下で入力してください。")]
    public string Model { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
    public string StarshipClass { get; set; } = string.Empty;
    [ValidateComplexType]
    public ShipDestination? Destination { get; set; }
}

public class ShipDestination
{
    [StringLength(100, ErrorMessage = "説明は100文字以下で入力してください。")]
    public string Description { get; set; } = string.Empty;
    [StringLength(20, ErrorMessage = "惑星名は20文字以下で入力してください。")]
    public string Planet { get; set; } = string.Empty;
}
