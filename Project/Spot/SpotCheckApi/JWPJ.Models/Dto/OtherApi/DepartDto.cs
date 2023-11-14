
namespace JWPJ.Models;

/// <summary>
/// 部门
/// </summary>
public class DepartDto
{
    /// <summary>
    /// 
    /// </summary>
    public string id { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string pid { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public decimal subcount { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string name { get; set; }


    /// <summary>
    /// 
    /// </summary>
    public string path { get; set; }


    /// <summary>
    /// 
    /// </summary>
    public decimal deptsort { get; set; }


    /// <summary>
    /// 
    /// </summary>
    public List<DepartDto> children { get; set; }

}
