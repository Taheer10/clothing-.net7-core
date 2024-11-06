using Mapster;
using System;
using System.Collections.Generic;
using ClothingPro.BusinessLayer.DTO;
using ClothingPro.BusinessLayer.Interface;
using ClothingPro.BusinessLayer.Mapper;
using ClothingPro.BusinessLayer.Repository;

namespace ClothingPro.BusinessLayer.BusinessService
{
    public class SettingService : ISettingService
    {
        private readonly SettingRepository _settingRepository;

        public SettingService(SettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }

        public List<SettingDTO> GetAllSetting()
        {
            try
            {

                var SettingDAOList = _settingRepository.SettingList();

                var SettingDTOList = SettingMapper.GetAllSettingDTO(SettingDAOList);
                return SettingDTOList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SettingDTO GetSettingById(string settingName)
        {
            try
            {

                var SettingDAO = _settingRepository.GetSettingById(settingName);
                var SettingDTOMOdel = SettingMapper.GetSettingDTO(SettingDAO);

                return SettingDTOMOdel;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string GetValueByName(string settingName)
        {
            try
            {

                return _settingRepository.GetSettingById(settingName).SettingValue;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public void UpdateSetting(SettingDTO settingDTO)
        {
            try
            {

                var SettingDAOModel = _settingRepository.GetSettingById(settingDTO.SettingName);

                settingDTO.Description = SettingDAOModel.Description;
                settingDTO.SettingType = SettingDAOModel.SettingType;

                var SettingModel = SettingMapper.GetSettingDAO(settingDTO);

                SettingModel.SettingName = SettingDAOModel.SettingName;

                SettingModel = SettingModel.Adapt(SettingDAOModel);

                _settingRepository.UpdateSetting(SettingModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}