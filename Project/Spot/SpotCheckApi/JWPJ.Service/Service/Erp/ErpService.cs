
namespace JWPJ.Service;

/// <summary>
/// ERP的接口
/// </summary>
public class ErpService:IErpService
{
    private readonly ISqlSugarClient _db;
    public ErpService(ISqlSugarClient db)
    {
        _db = db;
    }
    /// <summary>
    /// ERP固资、列管数据读取
    /// </summary>
    /// <param name="companyNo">公司别</param>
    /// <returns></returns>
    public async Task<List<ErpEquipmentDto>> ErpSyncData(string companyNo)
    {
        string dataBase = CompanyUtil.GetDataBaseName(companyNo);
        string sql = @$"SELECT  CASE WHEN faj04 IN ('510131','510132') THEN '列管' ELSE '固资' END EqumentType,
                        faj02 PropertyNumber,faj04 AssetClass,fab02 CategoryName,
                        faj06 CName,faj08 Spec,faj19 CustodyLaborNo,gen02 CustodyLaborName,nvl(fas02_max,faj26) EntryDate
                        FROM {dataBase}.faj_file
                        LEFT JOIN {dataBase}.fab_file ON fab01 = faj04
                        LEFT JOIN {dataBase}.gen_file ON gen01 = faj19
                        LEFT JOIN 
                        (select fat03,max(fas02) fas02_max 
                        from (
                            select fat03,fas02 from {dataBase}.fat_file,{dataBase}.fas_file 
                                    where fat01 = fas01 and faspost = 'Y' and fasconf = 'Y'
                            union all
                            select fbm04,fbl02 from {dataBase}.fbm_file,{dataBase}.fbl_file
                                    where fbm01 = fbl01 and fblpost = 'Y' and fblconf = 'Y'
                              )
                        group by fat03
                        ) on faj02 = fat03";
        return await _db.AsTenant().GetConnectionScope("ERP").Ado.SqlQueryAsync<ErpEquipmentDto>(sql);
    }

}
