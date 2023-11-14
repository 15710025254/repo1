
using JWPJ.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Mail;
using static Dm.net.buffer.ByteArrayBuffer;

namespace JWPJ.Service;

/// <summary>
/// 设备信息
/// </summary>
public class InsEquipmentInfService:SqlSugarRepository<InsEquipmentInf>, IInsEquipmentInfService
{
    private readonly ILogger<InsEquipmentInfService> _logger;
    private readonly SqlSugarRepository<InsEquipmentInf> _repository;
    private readonly ISqlSugarClient _db;
    private readonly IInsAttachmentService _InsAttachmentService;
    public InsEquipmentInfService(ILogger<InsEquipmentInfService> logger, SqlSugarRepository<InsEquipmentInf> repository, ISqlSugarClient db, IInsAttachmentService insAttachmentService)
    {
        _logger = logger;
        _repository = repository;
        _db = db;
        _InsAttachmentService = insAttachmentService;
    }

    /// <summary>
    ///  设备 分页查询
    /// </summary>
    /// <param name="param"></param>
    /// <returns></returns>
    public async Task<PageResult<InsEquipmentInfOutputDto>> GetInsEquipmentInfPageList(InsEquipmentInfInputDto param)
    {
        PageResult<InsEquipmentInfOutputDto> list = await _repository.AsQueryable().Includes(x => x.AttachmentImg)
            .Includes(x => x.EquipmentCate)
            .Includes(x => x.Classify)
            .WhereIF(!string.IsNullOrEmpty(param.Code), x => x.Code.Contains(param.Code))
            .WhereIF(!string.IsNullOrEmpty(param.Oldcode), x => x.Oldcode.Contains(param.Oldcode))
            .WhereIF(!string.IsNullOrEmpty(param.Name), x => x.Name.Contains(param.Name))
            .WhereIF(!string.IsNullOrEmpty(param.Gcode), x => x.Gcode.Contains(param.Gcode))
            .WhereIF(param.State != null, x => x.State == param.State)
            .WhereIF(param.OnState != null, x => x.OnState == param.OnState)
            .WhereIF(!string.IsNullOrEmpty(param.Head), x => x.Head.Contains(param.Head))
            .Select(x => new InsEquipmentInfOutputDto
            {
                Id = x.Id,
                Img = x.Img,
                ImgName = x.AttachmentImg.FileName,
                Code = x.Code,
                Oldcode = x.Oldcode,
                Name = x.Name,
                Gcode = x.Gcode,
                SerialNumber = x.SerialNumber,
                InsEquipmentCateId = x.InsEquipmentCateId,
                EquipmentCateName = x.EquipmentCate.Name,
                State = x.State,
                OnState = x.OnState,
                Head = x.Head,
                HeadNo = x.HeadNo,
                Brand = x.Brand,
                Spec = x.Spec,
                EquipmentLevel = x.EquipmentLevel,
                DepartId = x.DepartId,
                DepartName = x.DepartName,
                UserDepartId = x.UserDepartId,
                UserDepartName = x.UserDepartName,
                InsClassifyId = x.InsClassifyId,
                ClassifyName = x.Classify.Name,
                InsUnitId = x.InsUnitId,
                UnitName = x.Unit.Name,
                Supplier= x.Supplier,
                AcquisitionDate = x.AcquisitionDate,
                PurchaseAmount = x.PurchaseAmount,
                Currency=x.Currency,
                WarrantyDateTo=x.WarrantyDateTo,
                ActivationDate = x.ActivationDate,
                ExpectedScrapDate = x.ExpectedScrapDate,
                NetWorth=x.NetWorth,
                Source=x.Source,
                EquipmentParameters=x.EquipmentParameters,
                FileBatchNo=x.FileBatchNo,
                Attachment=x.Attachment,
                LabelCode=x.LabelCode,
                Describe = x.Describe,
                CreateBy = x.CreateBy,
                CreateTime = x.CreateTime
            }).ToPageAsync(param.PageIndex, param.PageSize);

        return list;

    }

    /// <summary>
    /// 设备 添加
    /// </summary>
    /// <param name="param"></param>
    /// <returns></returns>
    public async Task AddInsEquipmentInf(IFormFile img, IFormFile file, AddInsEquipmentInfInputDto param)
    {
        InsEquipmentInf insEquipmentInf = param.Adapt<InsEquipmentInf>();
        insEquipmentInf.Code = Utils.RadomGuid();
        if (img != null)
        {
            var imgInfo = await _InsAttachmentService.AddInsAttachment(img, "InsEquipmentInf");
            insEquipmentInf.Img = imgInfo.BatchNo;
        }
        if (file != null)
        {
            var imgInfo = await _InsAttachmentService.AddInsAttachment(img, "InsEquipmentInf", Utils.RandomFileBatchNo());
            insEquipmentInf.FileBatchNo = imgInfo.BatchNo;
        }
        await _repository.AddAsync(insEquipmentInf);

        //InsEquipmentInf insEquipmentInf = new InsEquipmentInf();
        //insEquipmentInf.Code = Utils.RadomGuid();
        //insEquipmentInf.Oldcode = param.Oldcode;
        //insEquipmentInf.Name = param.Name;
        //insEquipmentInf.Gcode = param.Gcode;
        //insEquipmentInf.SerialNumber = param.SerialNumber;
        //insEquipmentInf.InsEquipmentInfId = param.InsEquipmentInfId;
        //insEquipmentInf.State = param.State;
        //insEquipmentInf.OnState = param.OnState;
        //insEquipmentInf.Head=param.Head;
        //insEquipmentInf.HeadNo= param.HeadNo;
        //insEquipmentInf.Brand=param.Brand;
        //insEquipmentInf.Spec=param.Spec;
        //insEquipmentInf.EquipmentLevel=param.EquipmentLevel;
        //insEquipmentInf.DepartId=param.DepartId;
        //insEquipmentInf.DepartName=param.DepartName;
        //insEquipmentInf.UserDepartId=param.UserDepartId;
        //insEquipmentInf.UserDepartName=param.UserDepartName;

    }

    /// <summary>
    /// 设备 修改
    /// </summary>
    /// <param name="param">参数</param>
    /// <returns></returns>
    public async Task UpdateInsEquipmentInf(UpdateInsEquipmentInfInputDto param)
    {
        if (param.Id == 0)
            throw Oops.Oh(ErrorCodeEnum.D3004);
        if (string.IsNullOrWhiteSpace(param.Name))
            throw Oops.Oh(ErrorCodeEnum.D3002);

        InsEquipmentInf insEquipmentInf = param.Adapt<InsEquipmentInf>();
        await _repository.UpdateAsync(insEquipmentInf);
    }

    /// <summary>
    /// 设备 删除
    /// </summary>
    /// <param name="Id">主键ID</param>
    /// <returns></returns>
    public async Task DelInsEquipmentInf(long Id)
    {
        if (Id == 0)
            throw Oops.Oh(ErrorCodeEnum.D3004);

        await _repository.UpdateAsync(x => x.Id == Id, it => new InsEquipmentInf { IsPhantom = 1 });
    }

    #region 同步ERP资产到系统

    /// <summary>
    /// 批量添加设备 同步ERP资产到系统
    /// </summary>
    /// <param name="param"></param>
    /// <returns></returns>
    public async Task BeatchAddInsEquipmentInf(List<ErpEquipmentDto> param)
    {

        List<InsEquipmentInf> list = param.Select(x => new InsEquipmentInf
        {
            Code = Utils.RadomGuid(),//设备编号
           //InsEquipmentCateId =  x.EqumentType == "列管"?1: 2, //设备类别(列管、固资)
            Gcode=x.PropertyNumber,//资产编号
            InsEquipmentCateId =  x.AssetClass==""?1:0,//资产类别
            Name = x.CName,//设备名称
            Spec=x.Spec,//规格型号
            HeadNo = x.CustodyLaborNo,//保管人工号
            Head = x.CustodyLaborName,//保管人姓名
            AcquisitionDate = x.EntryDate,//入账日期
        }).ToList();
        await _repository.BatchFastestkAddAsync(list);
    }

    #endregion
}
