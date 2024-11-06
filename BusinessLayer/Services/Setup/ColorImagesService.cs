using Mapster;
using System;
using System.Collections.Generic;
using ClothingPro.BusinessLayer.DTO;
using ClothingPro.BusinessLayer.Interface;
using ClothingPro.BusinessLayer.Mapper;
using ClothingPro.BusinessLayer.Repository;
using ClothingPro.BusinessLayer.Helper;
using ClothingPro.DataAccessLayer.DbAccess;
using Microsoft.Data.SqlClient;
using System.Data;
using ClothingPro.Models;
using ClothingPro.DataAccessLayer.Model;

namespace ClothingPro.BusinessLayer.BusinessService
{
    public class ColorImagesService : IColorImagesService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ColorImagesRepository _colorImagesRepository;

        public ColorImagesService(UnitOfWork unitOfWork, ColorImagesRepository colorImagesRepository)
        {
            _unitOfWork = unitOfWork;
            _colorImagesRepository = colorImagesRepository;
        }

        public List<ColorImagesDTO> GetAllColorImages()
        {
            try
            {
                
                    var ColorImagesDAOList = _colorImagesRepository.ColorImagesList();

                    var ColorImagesDTOList = ColorImagesMapper.GetAllColorImagesDTO(ColorImagesDAOList).ToList();
                    return ColorImagesDTOList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ColorImagesDTO> GetAllColorImagesListByStockId(int stockId)
        {
            try
            {
               
                    var ColorImagesDAOList = _colorImagesRepository.ColorImagesListBYStockId(stockId);

                    var ColorImagesDTOList = ColorImagesMapper.GetAllColorImagesDTO(ColorImagesDAOList).ToList();
                    return ColorImagesDTOList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ColorImagesDTO GetColorImagesByIdd(int MnId)
        {
            try
            {
                var ColorImages = _colorImagesRepository.GetColorImagesByIdd(MnId);
                if (MnId > 0 && ColorImages != null)
                {
                    return ColorImagesMapper.GetColorImagesDTO(ColorImages);
                }
                else
                {
                    return new ColorImagesDTO();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ColorImagesDTO GetColorImagesById(string ColorImagesName)
        {
            try
            {
               
                    var ColorImagesDAO = _colorImagesRepository.GetColorImagesById(ColorImagesName);
                    var ColorImagesDTOMOdel = ColorImagesMapper.GetColorImagesDTO(ColorImagesDAO);

                    return ColorImagesDTOMOdel;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int CreateColorImages(ColorImagesDTO ColorImagesUI)
        {
            try
            {
                
                    var ColorImagesModel = ColorImagesMapper.GetColorImagesDAO(ColorImagesUI);
                    if (ColorImagesModel.ColorImagesId > 0)
                    {
                        var stockDAO = _colorImagesRepository.GetColorImagesByIdd(ColorImagesUI.ColorImagesId);
                        ColorImagesModel.ColorImagesId = stockDAO.ColorImagesId;

                        ColorImagesModel = ColorImagesModel.Adapt(stockDAO);
                        var result = _colorImagesRepository.UpdateColorImages(ColorImagesModel);
                        return ColorImagesUI.ColorImagesId;
                    }
                    else
                    {
                        return _colorImagesRepository.CreateColorImages(ColorImagesModel);
                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ColorImagesDTO>> CreateColorImagesList(List<ColorImagesDTO> ColorImagesList, int StockId)
        {
            await InsertColorImagesDetail(ColorImagesList, StockId);
            return ColorImagesList;
        }

        public async Task<List<ColorImagesDTO>> InsertColorImagesDetail(List<ColorImagesDTO> model, int Id)
        {


            try
            {

                

                    foreach (var item in model)
                    {
                        item.StockId = Id;
                    }

                    var ColorImagesDetailModel = await ColorImagesDetailList(model.ToList());


                    var createColorImagesDetail = ColorImagesDetailModel.Where(x => x.ColorImagesId == 0);
                    var updateColorImagesDetail = ColorImagesDetailModel.Where(x => x.ColorImagesId != 0);
                    ColorImagesDTO clr = new ColorImagesDTO();

                    if (createColorImagesDetail.Count() > 0)
                    {


                        //await unitOfWork.SaveChangesAsync()
                        //    .ConfigureAwait(false);
                        var saveCreateColorList = _colorImagesRepository.AddColorImagesRange(createColorImagesDetail.ToList());
                        return clr.colorImagesList;
                        
                    }

                    if (updateColorImagesDetail.Count() > 0)
                    {
                        var saveUpdateColorList = _colorImagesRepository.UpdateColorImagesRange(updateColorImagesDetail.ToList());
                        return clr.colorImagesList;

                    }

                    return model.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task<List<ColorImages>> ColorImagesDetailList(List<ColorImagesDTO> ColorImagesDetailList)
        {
            var ColorImagesDetaillList = ColorImagesDetailList.Select(x => new ColorImages
            {
                ColorImagesId = x.ColorImagesId,
                ColorImagesImg = x.ColorImagesImg,
                ColorImagesName = x.ColorImagesName,
                StockId = x.StockId,
                ColorName = x.ColorName,
                ColorNamePicker = x.ColorNamePicker
            }).ToList();

            return await Task.FromResult(ColorImagesDetaillList);
        }

        public string GetValueByName(string ColorImagesName)
        {
            try
            {
               
                    return _colorImagesRepository.GetColorImagesById(ColorImagesName).ColorImagesName;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public bool DeleteColorImages(int clrId)
        {
            try
            {

                    var result = _colorImagesRepository.DeleteColorImages(clrId);
                    return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }

}