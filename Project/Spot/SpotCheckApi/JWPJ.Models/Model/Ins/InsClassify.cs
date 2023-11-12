
namespace JWPJ.Models;

/// <summary>
/// 归属分类(区域) 基础数据
///</summary>
[Tenant("DORMITORY"), SugarTable("INS_CLASSIFY")]
public class InsClassify : ModelBase
{
    /// <summary>
    ///  编码
    ///</summary>
    [SugarColumn(ColumnName = "CODE")]
    public string Code { get; set; }
    /// <summary>
    ///  名称
    ///</summary>
    [SugarColumn(ColumnName = "NAME")]
    public string Name { get; set; }
    /// <summary>
    ///  类型
    ///</summary>
    [SugarColumn(ColumnName = "STYPE")]
    public ClassifyEnum Stype { get; set; } = ClassifyEnum.System;
    /// <summary>
    ///  归属
    ///</summary>
    [SugarColumn(ColumnName = "BELONGING")]
    public string Belonging { get; set; }

    /// <summary>
    /// 父ID
    ///</summary>
    [SugarColumn(ColumnName = "PID")]
    public long Pid { get; set; }

    /// <summary>
    /// 部门ID
    ///</summary>
    [SugarColumn(ColumnName = "DEPART_ID")]
    public decimal DepartId { get; set; }

    /// <summary>
    /// 是否启用
    ///</summary>
    [SugarColumn(ColumnName = "IS_ENABLE")]
    public IsEnableEnum IsEnable { get; set; } = IsEnableEnum.Enable;

    /// <summary>
    /// 排序
    ///</summary>
    [SugarColumn(ColumnName = "NUM")]
    public int Num { get; set; }

    /// <summary>
    ///  描述
    ///</summary>
    [SugarColumn(ColumnName = "DESCRIBE")]
    public string Describe { get; set; }

    /// <summary>
    /// 子项
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public List<InsClassify> Children { get; set; }

}
