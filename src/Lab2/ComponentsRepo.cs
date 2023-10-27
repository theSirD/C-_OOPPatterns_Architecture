using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents;
using Itmo.ObjectOrientedProgramming.Lab2.ComputerComponents.Storage;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class ComponentsRepo
{
    private static ComponentsRepo? _instance;
    private Dictionary<string, BaseRepoItem> _repo;

    private ComponentsRepo()
    {
        _repo = new Dictionary<string, BaseRepoItem>();
    }

    public static ComponentsRepo Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ComponentsRepo();
                _instance.Initialize();
            }

            return _instance;
        }
        set
        {
            _instance = value;
        }
    }

    public void Add(string name, BaseRepoItem component)
    {
        if (_repo.ContainsKey(name))
            throw new ArgumentException("Item with this name is already in repo");
        _repo.Add(name, component);
    }

    public BaseRepoItem Get(string name)
    {
        return _repo[name];
    }

    private void Initialize()
    {
        AddPCCases();
        AddMotherboards();
        AddBIOS();
        AddPowerPacks();
        AddXMP();
        AddCoolingSystem();
        AddCPUs();
        AddRAM();
        AddNetworkModules();
        AddDiscreteGPUs();
        AddSSDs();
        AddHDDs();
    }

    private void AddDiscreteGPUs()
    {
        _repo?.Add(
            "Nvidia GeForce RTX 3090 Ti",
            new DedicatedGPU(
                "Nvidia GeForce RTX 3090 Ti",
                31,
                11,
                24,
                4,
                1.86,
                450));

        _repo?.Add(
            "AMD Radeon RX 7900 XT",
            new DedicatedGPU(
                "AMD Radeon RX 7900 XT",
                27,
                12,
                16,
                5,
                2.2,
                350));

        _repo?.Add(
            "Intel Arc A770",
            new DedicatedGPU(
                "Intel Arc A770",
                27,
                12,
                16,
                5,
                2.3,
                300));

        _repo?.Add(
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

    private void AddMotherboards()
    {
        _repo?.Add(
            "ASUS ROG Strix Z690-A Gaming WiFi",
            new MotherBoard(
                "ASUS ROG Strix Z690-A Gaming WiFi",
                "LGA1700",
                20,
                6,
                5,
                4,
                true,
                6,
                MotherBoardFormFactors.NanoATX,
                2.1,
                5.3,
                true));

        _repo?.Add(
            "MSI MPG X570S Edge MAX WiFi",
            new MotherBoard(
                "MSI MPG X570S Edge MAX WiFi",
                "AM4",
                20,
                6,
                4,
                4,
                true,
                5,
                MotherBoardFormFactors.MiniATX,
                2.1,
                5.1,
                true));

        _repo?.Add(
            "Gigabyte B660 Aorus Master",
            new MotherBoard(
                "Gigabyte B660 Aorus Master",
                "AM4",
                16,
                6,
                5,
                4,
                true,
                4,
                MotherBoardFormFactors.MicroATX,
                2.1,
                5.1,
                false));

        _repo?.Add(
            "ASUS TUF Gaming B550-Plus",
            new MotherBoard(
                "ASUS TUF Gaming B550-Plus",
                "AM4",
                14,
                4,
                4,
                4,
                true,
                3,
                MotherBoardFormFactors.ATX,
                2.1,
                5.1,
                true));
    }

    private void AddBIOS()
    {
        _repo?.Add(
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
                    "AMD Ryzen 9 5950X",
                }));

        _repo?.Add(
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
        _repo?.Add(
            "Corsair iCUE 5000X RGB",
            new PCCase(
                "Corsair iCUE 5000X RGB",
                330,
                150,
                MotherBoardFormFactors.ATX));

        _repo?.Add(
            "NZXT H510 Elite",
            new PCCase(
                "NZXT H510 Elite",
                310,
                140,
                MotherBoardFormFactors.MiniATX));
    }

    private void AddNetworkModules()
    {
        _repo?.Add(
            "Intel Wi-Fi 6 AX200",
            new NetworkModule(
                "Intel Wi-Fi 6 AX200",
                6.0,
                true,
                4,
                10));

        _repo?.Add(
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
        _repo?.Add(
            "Corsair RM850x",
            new PowerPack(
                "Corsair RM850x",
                850));

        _repo?.Add(
            "EVGA SuperNOVA 1000 G5",
            new PowerPack(
                "EVGA SuperNOVA 1000 G5",
                115));
    }

    private void AddRAM()
    {
        _repo?.Add(
            "Kingston HyperX Fury RGB 32 GB (2 x 16 GB) DDR4-2000 CL16",
            new RAM(
                "Kingston HyperX Fury RGB 32 GB (2 x 16 GB) DDR4-3200 CL16",
                32,
                4,
                16,
                3.2));

        _repo?.Add(
            "Crucial Ballistix RGB 32 GB (2 x 16 GB) DDR4-3600 CL16",
            new RAM(
                "Crucial Ballistix RGB 32 GB (2 x 16 GB) DDR4-3600 CL16",
                32,
                4,
                16,
                2));
    }

    private void AddXMP()
    {
        _repo?.Add(
            "G.Skill Trident Z RGB 32GB (2x16GB) DDR4-3600 CL16 XMP Profile 1",
            new XMPProfile(
                "G.Skill Trident Z RGB 32GB (2x16GB) DDR4-3600 CL16 XMP Profile 1",
                1.35,
                3.6,
                "16-16-16-36"));

        _repo?.Add(
            "Kingston HyperX Fury RGB 32GB (2x16GB) DDR4-3200 CL16 XMP Profile 1",
            new XMPProfile(
                "G.Skill Trident Z RGB 32GB (2x16GB) DDR4-3600 CL16 XMP Profile 1",
                1.35,
                3.2,
                "16-18-18-36"));
    }

    private void AddCoolingSystem()
    {
        _repo?.Add(
        "Dark Rock Pro 4",
        new CoolingSystem(
            "Dark Rock Pro 4",
            new List<string?> { "LGA1700", "AM4", "TR4" },
            250,
            136,
            130));

        _repo?.Add(
            "Corsair iCUE H150i ELITE CAPELLIX",
            new CoolingSystem(
                "Corsair iCUE H150i ELITE CAPELLIX",
                new List<string?> { "AM4", "TR4" },
                300,
                160,
                150));
    }

    private void AddCPUs()
    {
        _repo?.Add(
            "Intel Core i9-12900K",
            new CPU(
                "Intel Core i9-12900K",
                3.2,
                16,
                "LGA1700",
                false,
                2.1,
                5.2,
                125,
                125));
        _repo?.Add(
            "AMD Ryzen 9 5950X",
            new CPU(
                "AMD Ryzen 9 5950X",
                3.4,
                16,
                "AM4",
                false,
                1.6,
                3.2,
                260,
                105));

        _repo?.Add(
            "Intel Core i7-12700K",
            new CPU(
                "Intel Core i7-12700K",
                3.6,
                12,
                "LGA1700",
                false,
                2.1,
                5,
                125,
                125));

        _repo?.Add(
            "AMD Ryzen 7 5800X",
            new CPU(
                "AMD Ryzen 7 5800X",
                3.8,
                8,
                "AM4",
                false,
                1.6,
                3.2,
                105,
                105));

        _repo?.Add(
            "Intel Core i5-12400",
            new CPU(
                "Intel Core i5-12400",
                2.5,
                6,
                "LGA1700",
                false,
                2.1,
                5,
                65,
                65));

        _repo?.Add(
            "AMD Ryzen 5 5600X",
            new CPU(
                "AMD Ryzen 5 5600X",
                3.7,
                6,
                "AM4",
                false,
                1.6,
                3.2,
                65,
                65));

        _repo?.Add(
            "Intel Core i3-12100F",
            new CPU(
                "Intel Core i3-12100F",
                3.3,
                4,
                "LGA1700",
                false,
                2.1,
                5,
                65,
                65));

        _repo?.Add(
            "AMD Ryzen 3 5300X",
            new CPU(
                "AMD Ryzen 3 5300X",
                3.8,
                4,
                "AM4",
                false,
                1.6,
                3.2,
                65,
                65));
    }

    private void AddSSDs()
    {
        _repo?.Add(
            "Samsung 980 Pro 1TB PCIe Gen4 NVMe SSD",
            new SSD(
                "Samsung 980 Pro 1TB PCIe Gen4 NVMe SSD",
                1000,
                7,
                6,
                SSDConnectionType.PCIE));

        _repo?.Add(
            "Samsung 870 QVO 500Gb SATA III SSD",
            new SSD(
                "Samsung 870 QVO 500Gb SATA III SSD",
                500,
                0.56,
                4,
                SSDConnectionType.SATA));

        _repo?.Add(
            "Western Digital Blue SN550 250GB NVMe SSD",
            new SSD(
                "Western Digital Blue SN550 250GB NVMe SSD",
                250,
                2.4,
                4,
                SSDConnectionType.PCIE));
    }

    private void AddHDDs()
    {
        _repo?.Add(
            "Toshiba MG09ACA18TE 18TB SATA III HDD",
            new HDD(
                "Toshiba MG09ACA18TE 18TB SATA III HDD",
                18000,
                0.25,
                7));

        _repo?.Add(
            "Seagate Barracuda 4TB SATA III HDD",
            new HDD(
                "Seagate Barracuda 4TB SATA III HDD",
                4000,
                0.15,
                6));
    }
}
