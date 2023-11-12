

namespace JWPJ.Core
{
    public class TokenModel
    {
        /// <summary>
        /// sys_user表ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 用户Id-账号
        /// </summary>
        public string Uid { get; set; }
        /// <summary>
        /// 用户名-姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 临时账号
        /// </summary>
        public string UserName2 { get; set; }
        /// <summary>
        /// 身份
        /// </summary>
        public List<RolesDto> Role { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string Project { get; set; }
        /// <summary>
        /// 令牌类型
        /// </summary>
        public string TokenType { get; set; }

        /// <summary>
        /// 公司类别
        /// </summary>
        public string COMPANY_NO { get; set; }
        /// <summary>
        /// 访问权限
        /// </summary>
        public List<CompanysDto> DeptScope { get; set; }
    }
    /// <summary>
    /// 角色集合
    /// </summary>
    public class RolesDto
    { 
        /// <summary>
        /// 数据权限
        /// </summary>
        public string DataScope { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public decimal Id { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 角色级别
        /// </summary>
        public decimal Level { get; set; }
    }

    /// <summary>
    /// 所属公司
    /// </summary>
    public class CompanysDto
    { 
        /// <summary>
        /// 公司编号（JW/JS/BD）
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        public string Pid { get; set; }
        /// <summary>
        /// 公司名称（合肥经纬/合肥精深/合肥博大）
        /// </summary>
        public string Name { get; set; }
    }
}
