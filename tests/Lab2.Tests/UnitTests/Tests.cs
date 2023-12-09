using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Responses;
using Itmo.ObjectOrientedProgramming.Lab2.CustomExceptions;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.UnitTests;

public class Tests
{
    [Fact]

    public void PerfectBuildTest()
    {
        var builder = new ComputerBuilder("PC1");
        builder.WithComputerCase("Corsair iCUE 5000X RGB");
        builder.WithMotherBoard("ASUS ROG Strix Z690-A Gaming WiFi");
        builder.WithBios("ASUS ROG Strix Z690-A Gaming WiFi BIOS");
        builder.WithCool("Dark Rock Pro 4");
        builder.WithPowerPack("Corsair RM850x");
        builder.WithXmp("G.Skill Trident Z RGB 32GB (2x16GB) DDR4-3600 CL16 XMP Profile 1");
        builder.WithCpu("Intel Core i9-12900K");
        builder.WithRam("Kingston HyperX Fury RGB 32 GB (2 x 16 GB) DDR4-2000 CL16");
        builder.WithDedicatedGpu("Nvidia GeForce RTX 3090 Ti");
        builder.WithSsd("Samsung 980 Pro 1TB PCIe Gen4 NVMe SSD");

        BuildResponse response = builder.Build();

        Assert.Equal("Success", response.Message);
    }

    [Fact]

    public void PowerConsumptionWarningTest()
    {
        var builder = new ComputerBuilder("PC2");
        builder.WithComputerCase("Corsair iCUE 5000X RGB");
        builder.WithMotherBoard("ASUS ROG Strix Z690-A Gaming WiFi");
        builder.WithBios("ASUS ROG Strix Z690-A Gaming WiFi BIOS");
        builder.WithCool("Dark Rock Pro 4");
        builder.WithPowerPack("EVGA SuperNOVA 1000 G5");
        builder.WithXmp("G.Skill Trident Z RGB 32GB (2x16GB) DDR4-3600 CL16 XMP Profile 1");
        builder.WithCpu("Intel Core i9-12900K");
        builder.WithRam("Kingston HyperX Fury RGB 32 GB (2 x 16 GB) DDR4-2000 CL16");
        builder.WithDedicatedGpu("Nvidia GeForce RTX 3090 Ti");
        builder.WithSsd("Samsung 980 Pro 1TB PCIe Gen4 NVMe SSD");

        BuildResponse response = builder.Build();

        Assert.Equal("Warning: More Powerful Power Pack Is Recommended", response.Message);
    }

    [Fact]

    public void TdpWarningTest()
    {
        var builder = new ComputerBuilder("PC3");
        builder.WithComputerCase("Corsair iCUE 5000X RGB");
        builder.WithMotherBoard("Gigabyte B660 Aorus Master");
        builder.WithBios("ASUS ROG Strix Z690-A Gaming WiFi BIOS");
        builder.WithCool("Dark Rock Pro 4");
        builder.WithPowerPack("EVGA SuperNOVA 1000 G5");
        builder.WithXmp("G.Skill Trident Z RGB 32GB (2x16GB) DDR4-3600 CL16 XMP Profile 1");
        builder.WithCpu("AMD Ryzen 9 5950X");
        builder.WithRam("Kingston HyperX Fury RGB 32 GB (2 x 16 GB) DDR4-2000 CL16");
        builder.WithDedicatedGpu("Nvidia GeForce RTX 3090 Ti");
        builder.WithSsd("Samsung 980 Pro 1TB PCIe Gen4 NVMe SSD");

        BuildResponse response = builder.Build();

        Assert.Equal("Disclaimer Of Warranty: Cooling System Is Not Powerful Enough", response.Message);
    }

    [Fact]

    public void BuildErrorTest1()
    {
        string warning = string.Empty;

        var builder = new ComputerBuilder("PC4");
        builder.WithComputerCase("Corsair iCUE 5000X RGB");
        builder.WithMotherBoard("ASUS ROG Strix Z690-A Gaming WiFi");
        builder.WithBios("ASUS ROG Strix Z690-A Gaming WiFi BIOS");
        try
        {
            builder.WithCool("Corsair iCUE H150i ELITE CAPELLIX");
        }
        catch (ComponentIsNotSupportedException e)
        {
            warning = e.Message;
        }

        Assert.Equal("Mother board does not support this cooling system", warning);
    }

    [Fact]
    public void BuildErrorTest2()
    {
        string warning = string.Empty;

        var builder = new ComputerBuilder("PC1");
        builder.WithComputerCase("Corsair iCUE 5000X RGB");
        builder.WithMotherBoard("ASUS ROG Strix Z690-A Gaming WiFi");
        builder.WithBios("ASUS ROG Strix Z690-A Gaming WiFi BIOS");
        builder.WithCool("Dark Rock Pro 4");
        builder.WithPowerPack("Corsair RM850x");
        builder.WithXmp("G.Skill Trident Z RGB 32GB (2x16GB) DDR4-3600 CL16 XMP Profile 1");
        builder.WithCpu("Intel Core i9-12900K");

        try
        {
            builder.WithRam("Crucial Ballistix RGB 32 GB (2 x 16 GB) DDR4-3600 CL16");
        }
        catch (ComponentIsNotSupportedException e)
        {
            warning = e.Message;
        }

        Assert.Equal("This RAM is too slow", warning);
    }
}