using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWPJ.Models;

/// <summary>
///点检项目模版 分页查询参数
/// </summary>
public class InsItemsTempInputDto:QueryCriteria
{
    /// <summary>
    /// 模版编号
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// 模版名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 项目选项
    /// </summary>
    public string Item { get; set; }
}

/// <summary>
/// 添加 点检项目模版参数
/// </summary>
public class AddInsItemsTempInputDto
{
    /// <summary>
    /// 模版名称
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 项目选项
    /// </summary>
    public string Item { get; set; }
}


/// <summary>
/// 修改 点检项目模版参数
/// </summary>
public class UpdateInsItemsTempInputDto: AddInsItemsTempInputDto
{
    public int Id { get; set; }

}
