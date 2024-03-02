using Microsoft.EntityFrameworkCore;

namespace HauseCalcApi.Tests;

public class CalculatorServiceIntegrationTests
{

    // ���������� �����
    // 1. ����������� ����
    // 1.1 ��������� ��� ��� ����������
    // 1.2 �������� �
    // 1.3 ��������� ��������� �������


    [Fact]
    public async Task GetWallsCost_MakeCalculation_ExpectedResultWasReturned()
    {
        // Arrange
        int areaHouseSquar = 100;
        int expected = 1600000;

        // 1.1 ��������� ��� ��� ����������
        var context = new AppContext("Data Source = :memory:");
        // 1.2 �������� �
        await ClearDatabaseAsync(context);
        // 1.3 ��������� ��������� �������
        await FillDatabaseAsync(context);

        var repo = new PriceRepository(context);
        CalculatorService calculatorService = new CalculatorService(repo);

        // Act
        int actual = await calculatorService.GetWallsCost(areaHouseSquar);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetProjectsCost_MakeCalculation_ExpectedResultWasReturned()
    {
        // Arrange
        int areaHouseSquar = 100;
        int expected = 65000;

        var context = new AppContext("Data Source = :memory:");
        await ClearDatabaseAsync(context);
        await FillDatabaseAsync(context);

        var repo = new PriceRepository(context);
        CalculatorService calculatorService = new CalculatorService(repo);

        // Act
        int actual = await calculatorService.GetProjectsCost(areaHouseSquar);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetGeologyCost_MakeCalculation_ExpectedResultWasReturned()
    {
        int expected = 40000;

        var context = new AppContext("Data Source = :memory:");
        await ClearDatabaseAsync(context);
        await FillDatabaseAsync(context);

        var repo = new PriceRepository(context);
        CalculatorService calculatorService = new CalculatorService(repo);
        int actual = await calculatorService.GetGeologyCost();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetGeodesyCost_MakeCalculation_ExpectedResultWasReturned()
    {
        int expected = 15000;

        var context = new AppContext("Data Source = :memory:");
        await ClearDatabaseAsync(context);
        await FillDatabaseAsync(context);

        var repo = new PriceRepository(context);
        CalculatorService calculatorService = new CalculatorService(repo);
        int actual = await calculatorService.GetGeodesyCost();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetConstructionCost_MakeCalculation_ExpectedResultWasReturned()
    {
        int areaHouseSquar = 100;
        int expected = 550000;

        var context = new AppContext("Data Source = :memory:");
        await ClearDatabaseAsync(context);
        await FillDatabaseAsync(context);

        var repo = new PriceRepository(context);
        CalculatorService calculatorService = new CalculatorService(repo);
        int actual = await calculatorService.GetConstructionCost(areaHouseSquar);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetArmo_MakeCalculation_ExpectedResultWasReturned()
    {
        int areaHouseSquar = 100;
        int expected = 30000;

        var context = new AppContext("Data Source = :memory:");
        await ClearDatabaseAsync(context);
        await FillDatabaseAsync(context);

        var repo = new PriceRepository(context);
        CalculatorService calculatorService = new CalculatorService(repo);
        int actual = await calculatorService.GetArmoCost(areaHouseSquar);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetSeamsCost_MakeCalculation_ExpectedResultWasReturned()
    {
        int areaHouseSquar = 100;
        int expected = 30000;

        var context = new AppContext("Data Source = :memory:");
        await ClearDatabaseAsync(context);
        await FillDatabaseAsync(context);

        var repo = new PriceRepository(context);
        CalculatorService calculatorService = new CalculatorService(repo);
        int actual = await calculatorService.GetSeamsCost(areaHouseSquar);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetDeliveryCost_MakeCalculation_ExpectedResultWasReturned()
    {
        int distanceKilometers = 50;
        int expected = 10000;

        var context = new AppContext("Data Source = :memory:");
        await ClearDatabaseAsync(context);
        await FillDatabaseAsync(context);

        var repo = new PriceRepository(context);
        CalculatorService calculatorService = new CalculatorService(repo);
        int actual = await calculatorService.GetDeliveryCost(distanceKilometers);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetFundationCost_MakeCalculation_ExpectedResultWasReturned()
    {
        int areaHouseSquar = 100;
        int expected = 1150000;

        var context = new AppContext("Data Source = :memory:");
        await ClearDatabaseAsync(context);
        await FillDatabaseAsync(context);

        var repo = new PriceRepository(context);
        CalculatorService calculatorService = new CalculatorService(repo);
        int actual = await calculatorService.GetFundationCost(areaHouseSquar);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetRoofCost_MakeCalculation_ExpectedResultWasReturned()
    {
        int areaHouseSquar = 100;
        int expected = 1350000;

        var context = new AppContext("Data Source = :memory:");
        await ClearDatabaseAsync(context);
        await FillDatabaseAsync(context);

        var repo = new PriceRepository(context);
        CalculatorService calculatorService = new CalculatorService(repo);
        int actual = await calculatorService.GetRoofCost(areaHouseSquar);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetWindowsCost_MakeCalculation_ExpectedResultWasReturned()
    {
        int filedWindowArea = 25;
        int expected = 387500;

        var context = new AppContext("Data Source = :memory:");
        await ClearDatabaseAsync(context);
        await FillDatabaseAsync(context);

        var repo = new PriceRepository(context);
        CalculatorService calculatorService = new CalculatorService(repo);
        int actual = await calculatorService.GetWindowsCost(filedWindowArea);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetDoorCost_MakeCalculation_ExpectedResultWasReturned()
    {
        int expected = 65000;

        var context = new AppContext("Data Source = :memory:");
        await ClearDatabaseAsync(context);
        await FillDatabaseAsync(context);

        var repo = new PriceRepository(context);
        CalculatorService calculatorService = new CalculatorService(repo);
        int actual = await calculatorService.GetDoorCost();

        Assert.Equal(expected, actual);
    }

    private static async Task FillDatabaseAsync(AppContext context)
    {
        await context.GetDatabase().ExecuteSqlAsync(
            $"""
            INSERT INTO Prices 
            ( "Id", "Name", "Value" )
            VALUES
            (1, "SetWalls", 16000),
            (2, "Projects", 650),
            (3, "Geology", 40000),
            (4, "Geodesy", 15000),
            (5, "Construction", 5500),
            (6, "Armo", 300),
            (7, "Seams", 300),
            (8, "Devilery", 200),
            (9, "Fundation", 11500),
            (10, "Roof", 13500),
            (11, "Windows", 15500),
            (12, "Door", 65000)
            """);
    }

    private static async Task ClearDatabaseAsync(AppContext context)
    {
        await context.GetDatabase().ExecuteSqlAsync($"DELETE FROM Prices");
    }
}