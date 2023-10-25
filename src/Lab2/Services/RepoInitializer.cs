using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Storage;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class RepoInitializer
{
    public ComponentsRepo? CurrentRepo { get;  set; }

    public void Initialize()
    {
        AddDiscreteGPUs();
        AddChipsets();
        AddMotherboards();
        AddBIOS();
        AddPCCases();
        AddNetworkModules();
        AddPowerPacks();
        AddRAM();
        AddXMP();
        AddCoolingSystem();
        AddCPUs();
        AddSSDs();
        AddHDDs();
    }

    private void AddDiscreteGPUs()
    {
        CurrentRepo?.Add(
            "Nvidia GeForce RTX 3090 Ti",
            new DedicatedGPU(
                "Nvidia GeForce RTX 3090 Ti",
                31,
                11,
                24,
                4,
                1.86,
                450));

        CurrentRepo?.Add(
            "AMD Radeon RX 7900 XT",
            new DedicatedGPU(
                "AMD Radeon RX 7900 XT",
                27,
                12,
                16,
                5,
                2.2,
                350));

        CurrentRepo?.Add(
            "Intel Arc A770",
            new DedicatedGPU(
                "Intel Arc A770",
                27,
                12,
                16,
                5,
                2.3,
                300));

        CurrentRepo?.Add(
            "ASUS ROG Strix RTX 3080 Ti",
            new DedicatedGPU(
                "ASUS ROG Strix RTX 3080 Ti",
                31,
                14,
                12,
                4,
                1.78,
                400));
    }

    private void AddChipsets()
    {
        CurrentRepo?.Add(
            "Intel Z690",
            new ChipSet(
                "Intel Z690",
                2.1,
                5.3,
                true));

        CurrentRepo?.Add(
            "AMD X570S",
            new ChipSet(
                "AMD X570S",
                2.1,
                5.1,
                true));

        CurrentRepo?.Add(
            "Intel B550",
            new ChipSet(
                "Intel B550",
                2.1,
                5.1,
                false));

        CurrentRepo?.Add(
            "AMD B550",
            new ChipSet(
                "AMD B550",
                2.1,
                5.1,
                true));
    }

    private void AddMotherboards()
    {
        CurrentRepo?.Add(
            "ASUS ROG Strix Z690-A Gaming WiFi",
            new MotherBoard(
                "ASUS ROG Strix Z690-A Gaming WiFi",
                "LGA 1700",
                20,
                6,
                null,
                5,
                4,
                true));

        CurrentRepo?.Add(
            "MSI MPG X570S Edge MAX WiFi",
            new MotherBoard(
                "MSI MPG X570S Edge MAX WiFi",
                "AM4",
                20,
                6,
                null,
                4,
                4,
                true));

        CurrentRepo?.Add(
            "Gigabyte B660 Aorus Master",
            new MotherBoard(
                "Gigabyte B660 Aorus Master",
                "LGA 1700",
                16,
                6,
                null,
                5,
                4,
                true));

        CurrentRepo?.Add(
            "ASUS TUF Gaming B550-Plus",
            new MotherBoard(
                "ASUS TUF Gaming B550-Plus",
                "AM4",
                14,
                4,
                null,
                4,
                4,
                true));
    }

    private void AddBIOS()
    {
        CurrentRepo?.Add(
            "ASUS ROG Strix Z690-A Gaming WiFi BIOS",
            new BIOS(
                "ASUS ROG Strix Z690-A Gaming WiFi BIOS",
                "UEFI",
                "1004",
                new List<string>
                {
                    "Intel Core i9-12900K",
                    "Intel Core i7-12700K",
                    "Intel Core i5-12600K",
                }));

        CurrentRepo?.Add(
            "MSI MPG X570S Edge MAX WiFi BIOS",
            new BIOS(
                "MSI MPG X570S Edge MAX WiFi BIOS",
                "UEFI",
                "7C95v1C",
                new List<string>
                {
                    "AMD Ryzen 9 5950X",
                    "AMD Ryzen 7 5800X",
                    "AMD Ryzen 5 5600X",
                }));
    }

    private void AddPCCases()
    {
        CurrentRepo?.Add(
            "Corsair iCUE 5000X RGB",
            new PCCase(
                "Corsair iCUE 5000X RGB",
                33,
                15,
                "ATX"));

        CurrentRepo?.Add(
            "NZXT H510 Elite",
            new PCCase(
                "NZXT H510 Elite",
                31,
                14,
                "ATX"));
    }

    private void AddNetworkModules()
    {
        CurrentRepo?.Add(
            "Intel Wi-Fi 6 AX200",
            new NetworkModule(
                "Intel Wi-Fi 6 AX200",
                6.0,
                true,
                4,
                10));

        CurrentRepo?.Add(
            "TP-Link Archer TX50E",
            new NetworkModule(
                "Intel Wi-Fi 6 AX200",
                6.0,
                false,
                3,
                5));
    }

    private void AddPowerPacks()
    {
        CurrentRepo?.Add(
            "Corsair RM850x",
            new PowerPack(
                "Corsair RM850x",
                850));

        CurrentRepo?.Add(
            "EVGA SuperNOVA 1000 G5",
            new PowerPack(
                "EVGA SuperNOVA 1000 G5",
                100));
    }

    private void AddRAM()
    {
        CurrentRepo?.Add(
            "Kingston HyperX Fury RGB 32 GB (2 x 16 GB) DDR4-3200 CL16",
            new RAM(
                "Kingston HyperX Fury RGB 32 GB (2 x 16 GB) DDR4-3200 CL16",
                32,
                4,
                16));

        CurrentRepo?.Add(
            "Crucial Ballistix RGB 32 GB (2 x 16 GB) DDR4-3600 CL16",
            new RAM(
                "Crucial Ballistix RGB 32 GB (2 x 16 GB) DDR4-3600 CL16",
                32,
                4,
                16));
    }

    private void AddXMP()
    {
        CurrentRepo?.Add(
            "G.Skill Trident Z RGB 32GB (2x16GB) DDR4-3600 CL16 XMP Profile 1",
            new XMPProfile(
                "G.Skill Trident Z RGB 32GB (2x16GB) DDR4-3600 CL16 XMP Profile 1",
                1.35,
                3600,
                "16-16-16-36"));

        CurrentRepo?.Add(
            "Kingston HyperX Fury RGB 32GB (2x16GB) DDR4-3200 CL16 XMP Profile 1",
            new XMPProfile(
                "G.Skill Trident Z RGB 32GB (2x16GB) DDR4-3600 CL16 XMP Profile 1",
                1.35,
                3200,
                "16-18-18-36"));
    }

    private void AddCoolingSystem()
    {
        CurrentRepo?.Add(
        "Dark Rock Pro 4",
        new CoolingSystem(
            "Dark Rock Pro 4",
            new List<string> { "LGA1700", "AM4", "TR4" },
            250));

        CurrentRepo?.Add(
            "Corsair iCUE H150i ELITE CAPELLIX",
            new CoolingSystem(
                "Corsair iCUE H150i ELITE CAPELLIX",
                new List<string> { "LGA1700", "AM4", "TR4" },
                300));
    }

    private void AddCPUs()
    {
        CurrentRepo?.Add(
            "Intel Core i9-12900K",
            new CPU(
                "Intel Core i9-12900K",
                3.2,
                16,
                "LGA1700",
                false,
                2133,
                5200,
                125,
                125));
        CurrentRepo?.Add(
            "AMD Ryzen 9 5950X",
            new CPU(
                "AMD Ryzen 9 5950X",
                3.4,
                16,
                "AM4",
                false,
                1600,
                3200,
                105,
                105));

        CurrentRepo?.Add(
            "Intel Core i7-12700K",
            new CPU(
                "Intel Core i7-12700K",
                3.6,
                12,
                "LGA1700",
                false,
                2133,
                5000,
                125,
                125));

        CurrentRepo?.Add(
            "AMD Ryzen 7 5800X",
            new CPU(
                "AMD Ryzen 7 5800X",
                3.8,
                8,
                "AM4",
                false,
                1600,
                3200,
                105,
                105));

        CurrentRepo?.Add(
            "Intel Core i5-12400",
            new CPU(
                "Intel Core i5-12400",
                2.5,
                6,
                "LGA1700",
                false,
                2133,
                5000,
                65,
                65));

        CurrentRepo?.Add(
            "AMD Ryzen 5 5600X",
            new CPU(
                "AMD Ryzen 5 5600X",
                3.7,
                6,
                "AM4",
                false,
                1600,
                3200,
                65,
                65));

        CurrentRepo?.Add(
            "Intel Core i3-12100F",
            new CPU(
                "Intel Core i3-12100F",
                3.3,
                4,
                "LGA1700",
                false,
                2133,
                5000,
                65,
                65));

        CurrentRepo?.Add(
            "AMD Ryzen 3 5300X",
            new CPU(
                "AMD Ryzen 3 5300X",
                3.8,
                4,
                "AM4",
                false,
                1600,
                3200,
                65,
                65));
    }

    private void AddSSDs()
    {
        CurrentRepo?.Add(
            "Samsung 980 Pro 1TB PCIe Gen4 NVMe SSD",
            new SSD(
                "Samsung 980 Pro 1TB PCIe Gen4 NVMe SSD",
                1000,
                7000,
                6,
                "PCIe Gen4 NVMe"));

        CurrentRepo?.Add(
            "Samsung 870 QVO 500Gb SATA III SSD",
            new SSD(
                "Samsung 870 QVO 500Gb SATA III SSD",
                500,
                560,
                4,
                "SATA III"));

        CurrentRepo?.Add(
            "Western Digital Blue SN550 250GB NVMe SSD",
            new SSD(
                "Western Digital Blue SN550 250GB NVMe SSD",
                250,
                2400,
                4,
                "NVMe"));
    }

    private void AddHDDs()
    {
        CurrentRepo?.Add(
            "Toshiba MG09ACA18TE 18TB SATA III HDD",
            new HDD(
                "Toshiba MG09ACA18TE 18TB SATA III HDD",
                18000,
                250,
                7));

        CurrentRepo?.Add(
            "Seagate Barracuda 4TB SATA III HDD",
            new HDD(
                "Seagate Barracuda 4TB SATA III HDD",
                4000,
                150,
                6));
    }
}
