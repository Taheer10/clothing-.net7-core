using Mapster;
using System;
using System.Linq;
using System.Collections.Generic;
using ClothingPro.BusinessLayer.DTO;
using ClothingPro.BusinessLayer.Interface;
using ClothingPro.BusinessLayer.Mapper;
using ClothingPro.BusinessLayer.Repository;
using Microsoft.Data.SqlClient;
using ClothingPro.BusinessLayer.Helper;
using System.Data;
using ClothingPro.DataAccessLayer.DbAccess;
using ClothingPro.Models;

namespace ClothingPro.BusinessLayer.BusinessService;
public class StockService : IStockService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly StockRepository _stockRepository;

    public StockService(UnitOfWork unitOfWork, StockRepository stockRepository)
    {
        _unitOfWork = unitOfWork;
        _stockRepository = stockRepository;
    }


    public List<StockDTO> GetAllStock()
    {
        try
        {
            SqlParameter[] sqlParameters = new SqlParameter[0];
            //sqlParameters[0] = new SqlParameter("@DoctorId", DoctorId);
            //sqlParameters[1] = new SqlParameter("@Name", Name);


            var ds = _unitOfWork.StockRepository.DataSetSqlQuery("[dbo].[sp_StockList]", true);

            List<StockDTO> StockDTOs = new();

            if (ds.Tables.Count > 0)
            {
                foreach (DataRow reader in ds.Tables[0].Rows)
                {
                    StockDTOs.Add(new StockDTO()
                    {
                        StId = Convert.ToInt32(reader["StId"]),
                        StName = DBNullHandler.String(reader["StName"]),
                        StDes = DBNullHandler.String(reader["StDes"]),
                        StCode = DBNullHandler.String(reader["StCode"]),
                        StImage = DBNullHandler.String(reader["StImage"]),
                        StInActive = DBNullHandler.Int32(reader["StInActive"], 0),
                        StIsPopular = DBNullHandler.Int32(reader["StIsPopular"], 0),
                        StHSCode = DBNullHandler.String(reader["StHSCode"]),
                        StColour = DBNullHandler.String(reader["StColour"]),
                        StSize = DBNullHandler.String(reader["StSize"]),
                        StIsPant = DBNullHandler.Int(reader["StIsPant"]),
                        StIsShirt = DBNullHandler.Int(reader["StIsShirt"]),
                        StIsOther = DBNullHandler.Int(reader["StIsOther"]),

                    });
                }
            }

            return StockDTOs;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public List<StockDTO> GetAllStockBYFilter(int IsActive)
    {
        try
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@IsActive", IsActive);



            var ds = _unitOfWork.StockRepository.DataSetSqlQuery("[dbo].[sp_StockListFilter]", true, sqlParameters);

            List<StockDTO> StockDTOs = new();

            if (ds.Tables.Count > 0)
            {
                foreach (DataRow reader in ds.Tables[0].Rows)
                {
                    StockDTOs.Add(new StockDTO()
                    {
                        StId = Convert.ToInt32(reader["StId"]),
                        StName = DBNullHandler.String(reader["StName"]),
                        StDes = DBNullHandler.String(reader["StDes"]),
                        StCode = DBNullHandler.String(reader["StCode"]),
                        StImage = DBNullHandler.String(reader["StImage"]),
                        StInActive = DBNullHandler.Int32(reader["StInActive"], 0),
                        StIsPopular = DBNullHandler.Int32(reader["StIsPopular"], 0),
                        StHSCode = DBNullHandler.String(reader["StHSCode"]),
                        StColour = DBNullHandler.String(reader["StColour"]),
                        StSize = DBNullHandler.String(reader["StSize"]),
                        StIsPant = DBNullHandler.Int(reader["StIsPant"]),
                        StIsShirt = DBNullHandler.Int(reader["StIsShirt"]),
                        StIsOther = DBNullHandler.Int(reader["StIsOther"]),

                    });
                }
            }

            return StockDTOs;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public List<StockDTO> GetLatestDetail(string FromDate, string ToDate)
    {
        try
        {
            //SqlParameter[] sqlParameters = new SqlParameter[2];
            //sqlParameters[0] = new SqlParameter("@FromDate", FromDate);
            //sqlParameters[1] = new SqlParameter("@ToDate", ToDate);



            //var ds = _unitOfWork.StockRepository.DataSetSqlQuery("[dbo].[sp_StockList]", true, sqlParameters);
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@FromDate", FromDate);
            sqlParameters[1] = new SqlParameter("@ToDate", ToDate);

            var ds = _unitOfWork.StockRepository.DataSetSqlQuery("[dbo].[sp_StockList]", true, sqlParameters);

            List<StockDTO> stockLatest = new();

            if (ds.Tables.Count > 0)
            {
                foreach (DataRow reader in ds.Tables[0].Rows)
                {
                    stockLatest.Add(new StockDTO()
                    {
                        StId = Convert.ToInt32(reader["StId"]),
                        StName = DBNullHandler.String(reader["StName"]),
                        StDes = DBNullHandler.String(reader["StDes"]),
                        StCode = DBNullHandler.String(reader["StCode"]),
                        StImage = DBNullHandler.String(reader["StImage"]),
                        StInActive = DBNullHandler.Int32(reader["StInActive"], 0),
                        StIsPopular = DBNullHandler.Int32(reader["StIsPopular"], 0),
                        StHSCode = DBNullHandler.String(reader["StHSCode"]),
                        StColour = DBNullHandler.String(reader["StColour"]),
                        StSize = DBNullHandler.String(reader["StSize"]),
                        StIsPant = DBNullHandler.Int(reader["StIsPant"]),
                        StIsShirt = DBNullHandler.Int(reader["StIsShirt"]),
                        StIsOther = DBNullHandler.Int(reader["StIsOther"]),
                        StMenuHeaderId = DBNullHandler.Int32(reader["StMenuHeaderId"]),
                        StAddedDate = DBNullHandler.DateTime(reader["StAddedDate"])

                    });
                }
            }

            return stockLatest;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public List<StockMenuView> GetStockMenuList(string search)
    {
        try
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@search", search);

            var ds = _unitOfWork.StockRepository.DataSetSqlQuery("sp_stockName", true, sqlParameters);

            List<StockMenuView> StockMenu = new List<StockMenuView>();

            if (ds.Tables.Count > 0)
            {
                foreach (DataRow reader in ds.Tables[0].Rows)
                {
                    StockMenu.Add(new StockMenuView()
                    {
                        StId = Convert.ToInt32(reader["StId"]),
                        StName = DBNullHandler.String(reader["StName"]),
                        StDes = DBNullHandler.String(reader["StDes"]),
                        StCode = DBNullHandler.String(reader["StCode"]),
                        StImage = DBNullHandler.String(reader["StImage"]),
                        StInActive = DBNullHandler.Int32(reader["StInActive"], 0),
                        StIsPopular = DBNullHandler.Int32(reader["StIsPopular"], 0),
                        StHSCode = DBNullHandler.String(reader["StHSCode"]),
                        StColour = DBNullHandler.String(reader["StColour"]),
                        StSize = DBNullHandler.String(reader["StSize"]),
                        StIsPant = DBNullHandler.Int(reader["StIsPant"]),
                        StIsShirt = DBNullHandler.Int(reader["StIsShirt"]),
                        StIsOther = DBNullHandler.Int(reader["StIsOther"]),
                        StMenuHeaderId = DBNullHandler.Int32(reader["StMenuHeaderId"]),
                        StAddedDate = DBNullHandler.DateTime(reader["StAddedDate"]),
                        MenuHeaderName = DBNullHandler.String(reader["MenuHeaderName"]),
                    });
                }
            }
            return StockMenu.ToList();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public StockDTO GetAllKindOfStock()
    {
        try
        {
            SqlParameter[] sqlParameters = new SqlParameter[0];
            //sqlParameters[0] = new SqlParameter("@DoctorId", DoctorId);
            //sqlParameters[1] = new SqlParameter("@Name", Name);


            var ds = _unitOfWork.StockRepository.DataSetSqlQuery("[dbo].[sp_StockDIfferentList]", true);

            StockDTO stocklist = new StockDTO();
            List<StockDTO> StockDTOs = new();
            List<StockDTO> stockPopularItems = new List<StockDTO>();
            List<StockDTO> stockPantsItems = new List<StockDTO>();


            if (ds.Tables.Count > 0)
            {
                foreach (DataRow reader in ds.Tables[0].Rows)
                {
                    stockPopularItems.Add(new StockDTO()
                    {
                        StId = Convert.ToInt32(reader["StId"]),
                        StName = DBNullHandler.String(reader["StName"]),
                        StDes = DBNullHandler.String(reader["StDes"]),
                        StCode = DBNullHandler.String(reader["StCode"]),
                        StImage = DBNullHandler.String(reader["StImage"]),
                        StInActive = DBNullHandler.Int32(reader["StInActive"], 0),
                        StIsPopular = DBNullHandler.Int32(reader["StIsPopular"], 0),
                        StHSCode = DBNullHandler.String(reader["StHSCode"]),
                        StColour = DBNullHandler.String(reader["StColour"]),
                        StSize = DBNullHandler.String(reader["StSize"]),
                        StIsPant = DBNullHandler.Int(reader["StIsPant"]),
                        StIsShirt = DBNullHandler.Int(reader["StIsShirt"]),
                        StIsOther = DBNullHandler.Int(reader["StIsOther"]),

                    });
                }
            }

            if (ds.Tables.Count > 1)
            {
                foreach (DataRow reader in ds.Tables[1].Rows)
                {
                    stockPantsItems.Add(new StockDTO()
                    {
                        StId = Convert.ToInt32(reader["StId"]),
                        StName = DBNullHandler.String(reader["StName"]),
                        StDes = DBNullHandler.String(reader["StDes"]),
                        StCode = DBNullHandler.String(reader["StCode"]),
                        StImage = DBNullHandler.String(reader["StImage"]),
                        StInActive = DBNullHandler.Int32(reader["StInActive"], 0),
                        StIsPopular = DBNullHandler.Int32(reader["StIsPopular"], 0),
                        StHSCode = DBNullHandler.String(reader["StHSCode"]),
                        StColour = DBNullHandler.String(reader["StColour"]),
                        StSize = DBNullHandler.String(reader["StSize"]),
                        StIsPant = DBNullHandler.Int(reader["StIsPant"]),
                        StIsShirt = DBNullHandler.Int(reader["StIsShirt"]),
                        StIsOther = DBNullHandler.Int(reader["StIsOther"]),

                    });
                }
            }
            stocklist.stockPopularList = stockPopularItems;
            stocklist.stockPantsList = stockPantsItems;

            return stocklist;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public StockDTO GetStockById(int stId)
    {
        try
        {
            var stockModel = _stockRepository.GetByStockId(stId);
            if (stockModel != null)
            {
                return StockMapper.GetStockDTO(stockModel);
            }
            else
            {
                return new StockDTO();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public StockDTO GetStockByBarcodeId(int? barcodeId)
    {
        try
        {
            //StockRepository stockRepo = new StockRepository();
            var stockmodel = _stockRepository.GetByStockBarcodeId(barcodeId);
            if (barcodeId > 0)
            {
                return StockMapper.GetStockDTO(stockmodel);
            }
            else
            {
                return new StockDTO();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public int CreateStock(StockDTO stockUI)
    {
        try
        {

            var stockModel = StockMapper.GetStockDAO(stockUI);
            if (stockModel.StId > 0)
            {
                var stockDAO = _stockRepository.GetByStockId(stockUI.StId);
                stockModel.StId = stockDAO.StId;
                stockModel.StFlagVal = stockUI.StFlagVal;

                stockModel = stockModel.Adapt(stockDAO);
                var result = _stockRepository.EditStock(stockModel);
                return stockUI.StId;
            }
            else
            {
                return _stockRepository.CreateStock(stockModel);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public bool DeleteStock(int stId)
    {
        try
        {

            //using (StockRepository stockRepo = new StockRepository())
            //{

            //    var result = stockRepo.DeleteStock(stId);
            //    return result;
            //}



            var result = _stockRepository.DeleteStock(stId);
            return result;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    public void UpdateStockRange(List<StockDTO> stockDTO)
    {
        try
        {

            var stockmodel = StockMapper.GetStockList(stockDTO);
            _stockRepository.EditStockRange(stockmodel.Where(x => x.StId > 0));
            _stockRepository.AddStockRange(stockmodel.Where(x => x.StId == 0));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}
