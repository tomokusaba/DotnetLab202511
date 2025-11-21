namespace DotnetLab202203.Models;

using Microsoft.Extensions.Validation;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// 宇宙船の基本情報と目的地情報を表す検証対象モデルです。
/// </summary>
#pragma warning disable ASP0029 // 種類は、評価の目的でのみ提供されています。将来の更新で変更または削除されることがあります。続行するには、この診断を非表示にします。
[ValidatableType]
#pragma warning restore ASP0029 // 種類は、評価の目的でのみ提供されています。将来の更新で変更または削除されることがあります。続行するには、この診断を非表示にします。
public class Starship
{
    /// <summary>
    /// 宇宙船の名称です。
    /// </summary>
    [StringLength(50, ErrorMessage = "名前は50文字以下で入力してください。")]
    [Required(ErrorMessage = "名前は必須項目です。")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 宇宙船のモデル名です。
    /// </summary>
    [StringLength(50, ErrorMessage = "モデルは50文字以下で入力してください。")]
    public string Model { get; set; } = string.Empty;

    /// <summary>
    /// 製造メーカー名です。
    /// </summary>
    public string Manufacturer { get; set; } = string.Empty;

    /// <summary>
    /// 宇宙船のクラス分類です。
    /// </summary>
    public string StarshipClass { get; set; } = string.Empty;

    /// <summary>
    /// 宇宙船の目的地情報です。
    /// </summary>
    public ShipDestination Destination { get; set; } = new();
}

/// <summary>
/// 宇宙船の目的地に関する詳細を保持します。
/// </summary>
public class ShipDestination
{
    /// <summary>
    /// 目的地の説明です。
    /// </summary>
    [StringLength(100, ErrorMessage = "説明は100文字以下で入力してください。")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// 目的地の惑星名です。
    /// </summary>
    [StringLength(20, ErrorMessage = "惑星名は20文字以下で入力してください。")]
    public string Planet { get; set; } = string.Empty;
}
