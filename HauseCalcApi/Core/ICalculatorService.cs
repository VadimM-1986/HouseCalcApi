using HauseCalcApi.Data;
using Microsoft.CodeAnalysis;

namespace HauseCalcApi.Core
{
    public interface ICalculatorService
    {
        Task<int> GetWallsCost(int areaHouseSquarMeters);
        Task<int> GetProjectsCost(int areaHouseSquarMeters);
        Task<int> GetGeologyCost();
        Task<int> GetGeodesyCost();
        Task<int> GetConstructionCost(int areaHouseSquarMeters);
        Task<int> GetArmoCost(int areaHouseSquarMeters);
        Task<int> GetSeamsCost(int areaHouseSquarMeters);
        Task<int> GetDeliveryCost(int distanceKilometers);
        Task<int> GetFundationCost(int areaHouseSquarMeters);
        Task<int> GetRoofCost(int areaHouseSquarMeters);
        Task<int> GetWindowsCost(int filedWindowArea);
        Task<int> GetDoorCost();
    }
}

