using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class MayorsPowers
    {
        /// <summary>市长能力内存表</summary>
        private static DataTable _MayorsPowerTable;

        /// <summary>市长能力内存表</summary>
        public static DataTable MayorsPowerTable
        {
            get
            {
                if (_MayorsPowerTable == null)
                {
                    LoadMayorsPowerTable();
                }
                return _MayorsPowerTable;
            }
            set { _MayorsPowerTable = value; }
        }

        /// <summary>读取市长能力列表</summary>
        public static void LoadMayorsPowerTable()
        {
            _MayorsPowerTable = null;
            string dpath = GetMayorsPowerTableXmlFilePath();
            try
            {
                _MayorsPowerTable = new DataTable();
                _MayorsPowerTable.ReadXml(dpath);
                _MayorsPowerTable.TableName = AppList.MayorsPowerTableName;
            }
            catch
            {
                _MayorsPowerTable = null;
            }
            if (_MayorsPowerTable == null)
            {
                CreatDefaultMayorsPowerTable();
            }
        }

        /// <summary>从指定路径读取市长能力列表</summary>
        /// <param name="path">指定路径</param>
        public static DataTable LoadMayorsPowerTable(string dpath)
        {
            DataTable dt = new DataTable();
            dt.ReadXml(dpath);
            dt.TableName = AppList.MayorsPowerTableName;
            return dt;
        }

        /// <summary>创建默认市长能力列表</summary>
        public static void CreatDefaultMayorsPowerTable()
        {
            _MayorsPowerTable = null;
            DataTable dt = AppList.GetConfigDataTable(AppList.MayorsPowerTableName);

            AddMayorsPower(dt, 1, "ExtraGold", "金钱奖励", "+", 400, 500, "", 1, 1, 0, "+,-", "");
            AddMayorsPower(dt, 1, "ExtraWood", "木材奖励", "+", 40, 100, "", 2, 1, 1, "+,-", "");
            AddMayorsPower(dt, 1, "ExtraStone", "石材奖励", "+", 20, 50, "", 3, 1, 2, "+,-", "");
            AddMayorsPower(dt, 1, "ExtraIron", "钢铁奖励", "+", 10, 30, "", 4, 1, 3, "+,-", "");
            AddMayorsPower(dt, 1, "ExtraOil", "石油奖励", "+", 10, 20, "", 5, 0, 4, "+,-", "");

            AddMayorsPower(dt, 1, "TechWoodHouse", "木屋技术", "", 1, 1, "", 1, 1, 5, "", "");
            AddMayorsPower(dt, 1, "TechFarms", "农场技术", "", 1, 1, "", 2, 1, 5, "", "");
            AddMayorsPower(dt, 1, "TechMarket", "市场技术", "", 1, 1, "", 3, 1, 5, "", "");
            AddMayorsPower(dt, 1, "TechSniper", "狙击手技术", "", 1, 1, "", 4, 1, 5, "", "");
            AddMayorsPower(dt, 1, "TechBallista", "大型弩车技术", "", 1, 1, "", 5, 1, 5, "", "");
            AddMayorsPower(dt, 1, "TechShockingTower", "震荡波塔技术", "", 1, 1, "", 6, 1, 5, "", "");

            AddMayorsPower(dt, 1, "TechStoneHouse", "石屋技术", "", 1, 1, "", 7, 0, 5, "", "");
            AddMayorsPower(dt, 1, "TechBank", "银行技术", "", 1, 1, "", 8, 0, 5, "", "");
            AddMayorsPower(dt, 1, "TechPowerPlant", "发电厂技术", "", 1, 1, "", 9, 0, 5, "", "");

            AddMayorsPower(dt, 1, "TechIronMill", "先进能源工坊技术", "", 1, 1, "", 10, 0, 5, "", "");
            AddMayorsPower(dt, 1, "TechAdvancedQuarry", "高级采石场技术", "", 1, 1, "", 11, 0, 5, "", "");
            AddMayorsPower(dt, 1, "TechAdvancedFarm", "高级农场技术", "", 1, 1, "", 12, 0, 5, "", "");
            AddMayorsPower(dt, 1, "TechExecutor", "机枪塔技术", "", 1, 1, "", 13, 0, 5, "", "");
            AddMayorsPower(dt, 1, "TechRadarTower", "雷达技术", "", 1, 1, "", 14, 0, 5, "", "");
            AddMayorsPower(dt, 1, "TechTrapBlades", "铁丝网陷阱技术", "", 1, 1, "", 15, 0, 5, "", "");

            AddMayorsPower(dt, 1, "Ranger", "游侠", "", 15, 20, "", 1, 1, 6, "", "");
            AddMayorsPower(dt, 1, "SoldierRegular", "士兵", "", 10, 15, "", 2, 1, 6, "", "");
            AddMayorsPower(dt, 1, "Sniper", "狙击手", "", 5, 10, "", 3, 1, 6, "", "");
            AddMayorsPower(dt, 1, "Lucifer", "坠天使", "", 3, 5, "", 4, 1, 6, "", "");
            AddMayorsPower(dt, 1, "Thanatos", "死神", "", 2, 3, "", 5, 1, 6, "", "");
            AddMayorsPower(dt, 1, "Titan", "泰坦", "", 2, 3, "", 6, 1, 6, "", "");

            AddMayorsPower(dt, 1, "MillWood", "能源工坊", "", 2, 5, "", 7, 1, 6, "", "");
            AddMayorsPower(dt, 1, "WallWood", "木墙", "", 100, 150, "", 8, 1, 6, "", "");
            AddMayorsPower(dt, 1, "GateWood", "木门", "", 5, 10, "", 9, 1, 6, "", "");
            AddMayorsPower(dt, 1, "WatchTowerWood", "木制哨塔", "", 20, 30, "", 10, 1, 6, "", "");
            AddMayorsPower(dt, 1, "LookoutTower", "瞭望塔", "", 2, 5, "", 11, 1, 6, "", "");
            AddMayorsPower(dt, 1, "Sawmill", "锯木厂", "", 2, 5, "", 12, 1, 6, "", "");
            AddMayorsPower(dt, 1, "Quarry", "采石场", "", 2, 5, "", 13, 1, 6, "", "");
            AddMayorsPower(dt, 1, "Farm", "农场", "", 2, 5, "", 14, 1, 6, "", "");
            AddMayorsPower(dt, 1, "HunterCottage ", "猎人小屋", "", 2, 5, "", 15, 1, 6, "", "");
            AddMayorsPower(dt, 1, "FishermanCottage", "捕鱼小屋", "", 2, 5, "", 16, 1, 6, "", "");
            AddMayorsPower(dt, 1, "EnergyWoodTower", "特斯拉塔", "", 2, 5, "", 17, 1, 6, "", "");

            AddMayorsPower(dt, 1, "ShockingTower", "震荡波塔", "", 2, 5, "", 18, 1, 6, "", "");
            AddMayorsPower(dt, 1, "Ballista", "大型弩车", "", 2, 5, "", 19, 1, 6, "", "");
            AddMayorsPower(dt, 1, "PowerPlant", "发电厂", "", 2, 5, "", 20, 0, 6, "", "");
            AddMayorsPower(dt, 1, "Executor", "机枪塔", "", 2, 5, "", 21, 0, 6, "", "");
            AddMayorsPower(dt, 1, "AdvancedQuarry", "高级采石场", "", 2, 5, "", 22, 0, 6, "", "");
            AddMayorsPower(dt, 1, "AdvancedFarm", "高级农场", "", 2, 5, "", 23, 0, 6, "", "");
            AddMayorsPower(dt, 1, "MillIron", "先进能源工坊", "", 2, 5, "", 24, 0, 6, "", "");
            AddMayorsPower(dt, 1, "RadarTower", "雷达", "", 2, 5, "", 25, 0, 6, "", "");
            AddMayorsPower(dt, 1, "WatchTowerStone", "石质哨塔", "", 10, 20, "", 26, 0, 6, "", "");
            AddMayorsPower(dt, 1, "WallStone", "石墙", "", 50, 80, "", 27, 0, 6, "", "");
            AddMayorsPower(dt, 1, "GateStone", "石门", "", 2, 5, "", 28, 0, 6, "", "");
            AddMayorsPower(dt, 1, "OilPlatform", "采油平台", "", 2, 5, "", 29, 0, 6, "", "");


            AddMayorsPower(dt, 1, "Sawmill WoodGen", "锯木厂木头产量", "+", 15, 20, "", 1, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 1, "Unit BuildingTimeFactor", "单位建造时间", "-", 25, 30, "%", 2, 0, 7, "+,-,=", "%");
            AddMayorsPower(dt, 1, "Structure BuildingTimeFactor", "建筑建造时间", "-", 25, 30, "%", 2, 0, 7, "+,-,=", "%");
            AddMayorsPower(dt, 1, "TentHouse WorkersSupply", "营帐提供工人", "+", 1, 3, "", 3, 0, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 1, "TentHouse GoldGen", "营帐金钱产量", "+", 120, 250, "%", 3, 0, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 1, "HunterCottage FoodSupply", "猎人小屋提供食物", "+", 20, 35, "", 4, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 1, "FishermanCottage FoodSupply", "捕鱼小屋提供食物", "+", 25, 45, "", 4, 0, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 1, "Quarry ResourceCollectionCellValue", "采石场每单元资源收集值", "+", 120, 250, "%", 5, 1, 7, "+,-,=", "%");
            AddMayorsPower(dt, 1, "CommandCenter GoldGen", "指挥中心金钱产量", "+", 150, 250, "", 6, 0, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 1, "CommandCenter ResourcesStorage", "指挥中心资源存储量", "+", 150, 250, "", 6, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 1, "MillWood EnergySupply", "能源工坊提供电力", "+", 20, 35, "", 7, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 1, "Unit GoldCost", "生产单位金钱消耗", "-", 20, 35, "%", 8, 0, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 1, "Structure GoldCost", "建造建筑金钱消耗", "-", 20, 35, "%", 9, 0, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 1, "Structure FactorResourcesReturn", "建筑拆除回收率", "=", 75, 85, "%", 10, 0, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 1, "EnergyWoodTower EnergyTransferRadius", "特斯拉塔能量传输范围", "+", 2, 4, "", 11, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 1, "EnergyWoodTower WatchRange", "特斯拉塔视野范围", "+", 2, 4, "", 12, 0, 7, "+,-,=", ",%");





            AddMayorsPower(dt, 2, "ExtraGold", "金钱奖励", "+", 1000, 2000, "", 1, 1, 0, "+,-", "");
            AddMayorsPower(dt, 2, "ExtraWood", "木材奖励", "+", 200, 400, "", 2, 1, 1, "+,-", "");
            AddMayorsPower(dt, 2, "ExtraStone", "石材奖励", "+", 100, 200, "", 3, 1, 2, "+,-", "");
            AddMayorsPower(dt, 2, "ExtraIron", "钢铁奖励", "+", 50, 100, "", 4, 1, 3, "+,-", "");
            AddMayorsPower(dt, 2, "ExtraOil", "石油奖励", "+", 20, 50, "", 5, 1, 4, "+,-", "");


            AddMayorsPower(dt, 2, "TechWoodHouse", "木屋技术", "", 1, 1, "", 1, 0, 5, "", "");
            AddMayorsPower(dt, 2, "TechFarms", "农场技术", "", 1, 1, "", 2, 0, 5, "", "");
            AddMayorsPower(dt, 2, "TechMarket", "市场技术", "", 1, 1, "", 3, 0, 5, "", "");
            AddMayorsPower(dt, 2, "TechSniper", "狙击手技术", "", 1, 1, "", 4, 0, 5, "", "");
            AddMayorsPower(dt, 2, "TechBallista", "大型弩车技术", "", 1, 1, "", 5, 0, 5, "", "");
            AddMayorsPower(dt, 2, "TechShockingTower", "震荡波塔技术", "", 1, 1, "", 6, 0, 5, "", "");

            AddMayorsPower(dt, 2, "TechStoneHouse", "石屋技术", "", 1, 1, "", 7, 1, 5, "", "");
            AddMayorsPower(dt, 2, "TechBank", "银行技术", "", 1, 1, "", 8, 1, 5, "", "");
            AddMayorsPower(dt, 2, "TechPowerPlant", "发电厂技术", "", 1, 1, "", 9, 1, 5, "", "");

            AddMayorsPower(dt, 2, "TechIronMill", "先进能源工坊技术", "", 1, 1, "", 10, 0, 5, "", "");
            AddMayorsPower(dt, 2, "TechAdvancedQuarry", "高级采石场技术", "", 1, 1, "", 11, 0, 5, "", "");
            AddMayorsPower(dt, 2, "TechAdvancedFarm", "高级农场技术", "", 1, 1, "", 12, 0, 5, "", "");
            AddMayorsPower(dt, 2, "TechExecutor", "机枪塔技术", "", 1, 1, "", 13, 0, 5, "", "");
            AddMayorsPower(dt, 2, "TechRadarTower", "雷达技术", "", 1, 1, "", 14, 0, 5, "", "");
            AddMayorsPower(dt, 2, "TechTrapBlades", "铁丝网陷阱技术", "", 1, 1, "", 15, 0, 5, "", "");

            AddMayorsPower(dt, 2, "Ranger", "游侠", "", 30, 40, "", 1, 1, 6, "", "");
            AddMayorsPower(dt, 2, "SoldierRegular", "士兵", "", 20, 30, "", 2, 1, 6, "", "");
            AddMayorsPower(dt, 2, "Sniper", "狙击手", "", 10, 15, "", 3, 1, 6, "", "");
            AddMayorsPower(dt, 2, "Lucifer", "坠天使", "", 8, 10, "", 4, 1, 6, "", "");
            AddMayorsPower(dt, 2, "Thanatos", "死神", "", 5, 8, "", 5, 1, 6, "", "");
            AddMayorsPower(dt, 2, "Titan", "泰坦", "", 5, 8, "", 6, 1, 6, "", "");

            AddMayorsPower(dt, 2, "MillWood", "能源工坊", "", 4, 6, "", 7, 0, 6, "", "");
            AddMayorsPower(dt, 2, "WallWood", "木墙", "", 200, 400, "", 8, 0, 6, "", "");
            AddMayorsPower(dt, 2, "GateWood", "木门", "", 20, 50, "", 9, 0, 6, "", "");
            AddMayorsPower(dt, 2, "WatchTowerWood", "木制哨塔", "", 50, 100, "", 10, 0, 6, "", "");
            AddMayorsPower(dt, 2, "LookoutTower", "瞭望塔", "", 4, 6, "", 11, 0, 6, "", "");
            AddMayorsPower(dt, 2, "Sawmill", "锯木厂", "", 4, 6, "", 12, 1, 6, "", "");
            AddMayorsPower(dt, 2, "Quarry", "采石场", "", 4, 6, "", 13, 0, 6, "", "");
            AddMayorsPower(dt, 2, "Farm", "农场", "", 4, 6, "", 14, 0, 6, "", "");
            AddMayorsPower(dt, 2, "HunterCottage ", "猎人小屋", "", 4, 6, "", 15, 1, 6, "", "");
            AddMayorsPower(dt, 2, "FishermanCottage", "捕鱼小屋", "", 4, 6, "", 16, 1, 6, "", "");
            AddMayorsPower(dt, 2, "EnergyWoodTower", "特斯拉塔", "", 4, 6, "", 17, 1, 6, "", "");

            AddMayorsPower(dt, 2, "ShockingTower", "震荡波塔", "", 4, 6, "", 18, 1, 6, "", "");
            AddMayorsPower(dt, 2, "Ballista", "大型弩车", "", 4, 6, "", 19, 1, 6, "", "");
            AddMayorsPower(dt, 2, "PowerPlant", "发电厂", "", 4, 6, "", 20, 1, 6, "", "");
            AddMayorsPower(dt, 2, "Executor", "机枪塔", "", 4, 6, "", 21, 1, 6, "", "");
            AddMayorsPower(dt, 2, "AdvancedQuarry", "高级采石场", "", 4, 6, "", 22, 1, 6, "", "");
            AddMayorsPower(dt, 2, "AdvancedFarm", "高级农场", "", 4, 6, "", 23, 1, 6, "", "");
            AddMayorsPower(dt, 2, "MillIron", "先进能源工坊", "", 4, 6, "", 24, 1, 6, "", "");
            AddMayorsPower(dt, 2, "RadarTower", "雷达", "", 4, 6, "", 25, 1, 6, "", "");
            AddMayorsPower(dt, 2, "WatchTowerStone", "石质哨塔", "", 30, 50, "", 26, 1, 6, "", "");
            AddMayorsPower(dt, 2, "WallStone", "石墙", "", 100, 150, "", 27, 1, 6, "", "");
            AddMayorsPower(dt, 2, "GateStone", "石门", "", 10, 20, "", 28, 1, 6, "", "");
            AddMayorsPower(dt, 2, "OilPlatform", "采油平台", "", 4, 6, "", 29, 1, 6, "", "");


            AddMayorsPower(dt, 2, "Sawmill WoodGen", "锯木厂木头产量", "+", 20, 30, "", 1, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 2, "Unit BuildingTimeFactor", "单位建造时间", "-", 30, 33, "%", 2, 1, 7, "+,-,=", "%");
            AddMayorsPower(dt, 2, "Structure BuildingTimeFactor", "建筑建造时间", "-", 30, 33, "%", 2, 1, 7, "+,-,=", "%");
            AddMayorsPower(dt, 2, "CottageHouse WorkersSupply", "木屋提供工人", "+", 2, 4, "", 3, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 2, "CottageHouse GoldGen", "木屋金钱产量", "+", 120, 250, "%", 3, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 2, "HunterCottage FoodSupply", "猎人小屋提供食物", "+", 45, 55, "", 4, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 2, "FishermanCottage FoodSupply", "捕鱼小屋提供食物", "+", 55, 65, "", 4, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 2, "Farm FoodSupply", "农场提供食物", "+", 65, 85, "", 4, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 2, "Quarry ResourceCollectionCellValue", "采石场每单元资源收集值", "+", 150, 250, "%", 5, 1, 7, "+,-,=", "%");
            AddMayorsPower(dt, 2, "CommandCenter GoldGen", "指挥中心金钱产量", "+", 250, 450, "", 6, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 2, "CommandCenter ResourcesStorage", "指挥中心资源存储量", "+", 250, 550, "", 6, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 2, "MillWood EnergySupply", "能源工坊提供电力", "+", 35, 65, "", 7, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 2, "Unit GoldCost", "生产单位金钱消耗", "-", 30, 45, "%", 8, 0, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 2, "Structure GoldCost", "建造建筑金钱消耗", "-", 30, 45, "%", 9, 0, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 2, "Structure FactorResourcesReturn", "建筑拆除回收率", "=", 85, 95, "%", 10, 0, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 2, "EnergyWoodTower EnergyTransferRadius", "特斯拉塔能量传输范围", "+", 4, 6, "", 11, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 2, "EnergyWoodTower WatchRange", "特斯拉塔视野范围", "+", 4, 6, "", 12, 0, 7, "+,-,=", ",%");





            AddMayorsPower(dt, 3, "ExtraGold", "金钱奖励", "+", 5000, 8000, "", 1, 1, 0, "+,-", "");
            AddMayorsPower(dt, 3, "ExtraWood", "木材奖励", "+", 400, 800, "", 2, 1, 1, "+,-", "");
            AddMayorsPower(dt, 3, "ExtraStone", "石材奖励", "+", 200, 400, "", 3, 1, 2, "+,-", "");
            AddMayorsPower(dt, 3, "ExtraIron", "钢铁奖励", "+", 100, 200, "", 4, 1, 3, "+,-", "");
            AddMayorsPower(dt, 3, "ExtraOil", "石油奖励", "+", 50, 100, "", 5, 1, 4, "+,-", "");


            AddMayorsPower(dt, 3, "TechWoodHouse", "木屋技术", "", 1, 1, "", 1, 0, 5, "", "");
            AddMayorsPower(dt, 3, "TechFarms", "农场技术", "", 1, 1, "", 2, 0, 5, "", "");
            AddMayorsPower(dt, 3, "TechMarket", "市场技术", "", 1, 1, "", 3, 0, 5, "", "");
            AddMayorsPower(dt, 3, "TechSniper", "狙击手技术", "", 1, 1, "", 4, 0, 5, "", "");
            AddMayorsPower(dt, 3, "TechBallista", "大型弩车技术", "", 1, 1, "", 5, 0, 5, "", "");
            AddMayorsPower(dt, 3, "TechShockingTower", "震荡波塔技术", "", 1, 1, "", 6, 0, 5, "", "");

            AddMayorsPower(dt, 3, "TechStoneHouse", "石屋技术", "", 1, 1, "", 7, 0, 5, "", "");
            AddMayorsPower(dt, 3, "TechBank", "银行技术", "", 1, 1, "", 8, 0, 5, "", "");
            AddMayorsPower(dt, 3, "TechPowerPlant", "发电厂技术", "", 1, 1, "", 9,0, 5, "", "");

            AddMayorsPower(dt, 3, "TechIronMill", "先进能源工坊技术", "", 1, 1, "", 10, 1, 5, "", "");
            AddMayorsPower(dt, 3, "TechAdvancedQuarry", "高级采石场技术", "", 1, 1, "", 11, 1, 5, "", "");
            AddMayorsPower(dt, 3, "TechAdvancedFarm", "高级农场技术", "", 1, 1, "", 12, 1, 5, "", "");
            AddMayorsPower(dt, 3, "TechExecutor", "机枪塔技术", "", 1, 1, "", 13, 1, 5, "", "");
            AddMayorsPower(dt, 3, "TechRadarTower", "雷达技术", "", 1, 1, "", 14, 1, 5, "", "");
            AddMayorsPower(dt, 3, "TechTrapBlades", "铁丝网陷阱技术", "", 1, 1, "", 15, 1, 5, "", "");

            AddMayorsPower(dt, 3, "Ranger", "游侠", "", 60, 80, "", 1, 1, 6, "", "");
            AddMayorsPower(dt, 3, "SoldierRegular", "士兵", "", 40, 60, "", 2, 1, 6, "", "");
            AddMayorsPower(dt, 3, "Sniper", "狙击手", "", 30, 40, "", 3, 1, 6, "", "");
            AddMayorsPower(dt, 3, "Lucifer", "坠天使", "", 15, 20, "", 4, 1, 6, "", "");
            AddMayorsPower(dt, 3, "Thanatos", "死神", "", 10, 15, "", 5, 1, 6, "", "");
            AddMayorsPower(dt, 3, "Titan", "泰坦", "", 8, 10, "", 6, 1, 6, "", "");

            AddMayorsPower(dt, 3, "MillWood", "能源工坊", "", 6, 8, "", 7, 0, 6, "", "");
            AddMayorsPower(dt, 3, "WallWood", "木墙", "", 400, 800, "", 8, 0, 6, "", "");
            AddMayorsPower(dt, 3, "GateWood", "木门", "", 50, 100, "", 9, 0, 6, "", "");
            AddMayorsPower(dt, 3, "WatchTowerWood", "木制哨塔", "", 100, 200, "", 10, 0, 6, "", "");
            AddMayorsPower(dt, 3, "LookoutTower", "瞭望塔", "", 6, 8, "", 11, 0, 6, "", "");
            AddMayorsPower(dt, 3, "Sawmill", "锯木厂", "", 6, 8, "", 12, 1, 6, "", "");
            AddMayorsPower(dt, 3, "Quarry", "采石场", "", 6, 8, "", 13, 0, 6, "", "");
            AddMayorsPower(dt, 3, "Farm", "农场", "", 6, 8, "", 14, 0, 6, "", "");
            AddMayorsPower(dt, 3, "HunterCottage ", "猎人小屋", "", 6, 8, "", 15, 1, 6, "", "");
            AddMayorsPower(dt, 3, "FishermanCottage", "捕鱼小屋", "", 6, 8, "", 16, 1, 6, "", "");
            AddMayorsPower(dt, 3, "EnergyWoodTower", "特斯拉塔", "", 6, 8, "", 17, 1, 6, "", "");

            AddMayorsPower(dt, 3, "ShockingTower", "震荡波塔", "", 6, 8, "", 18, 1, 6, "", "");
            AddMayorsPower(dt, 3, "Ballista", "大型弩车", "", 6, 8, "", 19, 1, 6, "", "");
            AddMayorsPower(dt, 3, "PowerPlant", "发电厂", "", 6, 8, "", 20, 1, 6, "", "");
            AddMayorsPower(dt, 3, "Executor", "机枪塔", "", 6, 8, "", 21, 1, 6, "", "");
            AddMayorsPower(dt, 3, "AdvancedQuarry", "高级采石场", "", 6, 8, "", 22, 1, 6, "", "");
            AddMayorsPower(dt, 3, "AdvancedFarm", "高级农场", "", 6, 8, "", 23, 1, 6, "", "");
            AddMayorsPower(dt, 3, "MillIron", "先进能源工坊", "", 6, 8, "", 24, 1, 6, "", "");
            AddMayorsPower(dt, 3, "RadarTower", "雷达", "", 6, 8, "", 25, 1, 6, "", "");
            AddMayorsPower(dt, 3, "WatchTowerStone", "石质哨塔", "", 100, 200, "", 26, 1, 6, "", "");
            AddMayorsPower(dt, 3, "WallStone", "石墙", "", 300, 400, "", 27, 1, 6, "", "");
            AddMayorsPower(dt, 3, "GateStone", "石门", "", 20, 30, "", 28, 1, 6, "", "");
            AddMayorsPower(dt, 3, "OilPlatform", "采油平台", "", 6, 8, "", 29, 1, 6, "", "");

            AddMayorsPower(dt, 3, "Sawmill WoodGen", "锯木厂木头产量", "+", 30, 45, "", 1, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 3, "Unit BuildingTimeFactor", "单位建造时间", "-", 30, 33, "%", 2, 1, 7, "+,-,=", "%");
            AddMayorsPower(dt, 3, "Structure BuildingTimeFactor", "建筑建造时间", "-", 30, 33, "%", 2, 1, 7, "+,-,=", "%");
            AddMayorsPower(dt, 3, "StoneHouse WorkersSupply", "石屋提供工人", "+", 6, 12, "", 3, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 3, "StoneHouse GoldGen", "石屋金钱产量", "+", 150, 250, "%", 3, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 3, "HunterCottage FoodSupply", "猎人小屋提供食物", "+", 55, 65, "", 4, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 3, "FishermanCottage FoodSupply", "捕鱼小屋提供食物", "+", 65, 75, "", 4, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 3, "AdvancedFarm FoodSupply", "高级农场提供食物", "+", 95, 105, "", 4, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 3, "AdvancedQuarry ResourceCollectionCellValue", "高级采石场每单元资源收集值", "+", 250, 350, "%", 5, 1, 7, "+,-,=", "%");
            AddMayorsPower(dt, 3, "CommandCenter GoldGen", "指挥中心金钱产量", "+", 450, 850, "", 6, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 3, "CommandCenter ResourcesStorage", "指挥中心资源存储量", "+", 550, 850, "", 6, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 3, "MillIron EnergySupply", "先进能源工坊提供电力", "+", 85, 150, "", 7, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 3, "Unit GoldCost", "生产单位金钱消耗", "-", 40, 55, "%", 8, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 3, "Structure GoldCost", "建造建筑金钱消耗", "-", 40, 55, "%", 9, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 3, "Structure FactorResourcesReturn", "建筑拆除回收率", "=", 95, 100, "%", 10, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 3, "EnergyWoodTower EnergyTransferRadius", "特斯拉塔能量传输范围", "+", 6, 10, "", 11, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 3, "EnergyWoodTower WatchRange", "特斯拉塔视野范围", "+", 6, 10, "", 12, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 3, "WallStone Life", "石墙生命", "+", 150, 200, "%", 13, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 3, "WatchTowerStone Life", "石质哨塔生命", "+", 200, 350, "%", 14, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 3, "OilPlatform OilGen", "采油平台石油产出", "+", 15, 20, "", 15, 1, 7, "+,-,=", ",%");




            AddMayorsPower(dt, 4, "ExtraGold", "金钱奖励", "+", 10000, 20000, "", 1, 1, 0, "+,-", "");
            AddMayorsPower(dt, 4, "ExtraWood", "木材奖励", "+", 1000, 2000, "", 2, 1, 1, "+,-", "");
            AddMayorsPower(dt, 4, "ExtraStone", "石材奖励", "+", 500, 1000, "", 3, 1, 2, "+,-", "");
            AddMayorsPower(dt, 4, "ExtraIron", "钢铁奖励", "+", 400, 500, "", 4, 1, 3, "+,-", "");
            AddMayorsPower(dt, 4, "ExtraOil", "石油奖励", "+", 200, 300, "", 5, 1, 4, "+,-", "");

            AddMayorsPower(dt, 4, "TechWoodHouse", "木屋技术", "", 1, 1, "", 1, 0, 5, "", "");
            AddMayorsPower(dt, 4, "TechFarms", "农场技术", "", 1, 1, "", 2, 0, 5, "", "");
            AddMayorsPower(dt, 4, "TechMarket", "市场技术", "", 1, 1, "", 3, 0, 5, "", "");
            AddMayorsPower(dt, 4, "TechSniper", "狙击手技术", "", 1, 1, "", 4, 0, 5, "", "");
            AddMayorsPower(dt, 4, "TechBallista", "大型弩车技术", "", 1, 1, "", 5, 0, 5, "", "");
            AddMayorsPower(dt, 4, "TechShockingTower", "震荡波塔技术", "", 1, 1, "", 6, 0, 5, "", "");

            AddMayorsPower(dt, 4, "TechStoneHouse", "石屋技术", "", 1, 1, "", 7, 0, 5, "", "");
            AddMayorsPower(dt, 4, "TechBank", "银行技术", "", 1, 1, "", 8, 0, 5, "", "");
            AddMayorsPower(dt, 4, "TechPowerPlant", "发电厂技术", "", 1, 1, "", 9, 0, 5, "", "");

            AddMayorsPower(dt, 4, "TechIronMill", "先进能源工坊技术", "", 1, 1, "", 10, 0, 5, "", "");
            AddMayorsPower(dt, 4, "TechAdvancedQuarry", "高级采石场技术", "", 1, 1, "", 11, 0, 5, "", "");
            AddMayorsPower(dt, 4, "TechAdvancedFarm", "高级农场技术", "", 1, 1, "", 12, 0, 5, "", "");
            AddMayorsPower(dt, 4, "TechExecutor", "机枪塔技术", "", 1, 1, "", 13, 0, 5, "", "");
            AddMayorsPower(dt, 4, "TechRadarTower", "雷达技术", "", 1, 1, "", 14, 0, 5, "", "");
            AddMayorsPower(dt, 4, "TechTrapBlades", "铁丝网陷阱技术", "", 1, 1, "", 15, 0, 5, "", "");

            AddMayorsPower(dt, 4, "Ranger", "游侠", "", 100, 200, "", 1, 1, 6, "", "");
            AddMayorsPower(dt, 4, "SoldierRegular", "士兵", "", 60, 80, "", 2, 1, 6, "", "");
            AddMayorsPower(dt, 4, "Sniper", "狙击手", "", 40, 60, "", 3, 1, 6, "", "");
            AddMayorsPower(dt, 4, "Lucifer", "坠天使", "", 30, 40, "", 4, 1, 6, "", "");
            AddMayorsPower(dt, 4, "Thanatos", "死神", "", 20, 30, "", 5, 1, 6, "", "");
            AddMayorsPower(dt, 4, "Titan", "泰坦", "", 15, 20, "", 6, 1, 6, "", "");

            AddMayorsPower(dt, 4, "MillWood", "能源工坊", "", 10, 15, "", 7, 0, 6, "", "");
            AddMayorsPower(dt, 4, "WallWood", "木墙", "", 2000, 4000, "", 8, 0, 6, "", "");
            AddMayorsPower(dt, 4, "GateWood", "木门", "", 100, 200, "", 9, 0, 6, "", "");
            AddMayorsPower(dt, 4, "WatchTowerWood", "木制哨塔", "", 400, 600, "", 10, 0, 6, "", "");
            AddMayorsPower(dt, 4, "LookoutTower", "瞭望塔", "", 10, 15, "", 11, 0, 6, "", "");
            AddMayorsPower(dt, 4, "Sawmill", "锯木厂", "", 10, 15, "", 12, 0, 6, "", "");
            AddMayorsPower(dt, 4, "Quarry", "采石场", "", 10, 15, "", 13, 0, 6, "", "");
            AddMayorsPower(dt, 4, "Farm", "农场", "", 10, 15, "", 14, 0, 6, "", "");
            AddMayorsPower(dt, 4, "HunterCottage ", "猎人小屋", "", 10, 15, "", 15, 0, 6, "", "");
            AddMayorsPower(dt, 4, "FishermanCottage", "捕鱼小屋", "", 10, 15, "", 16, 0, 6, "", "");
            AddMayorsPower(dt, 4, "EnergyWoodTower", "特斯拉塔", "", 10, 15, "", 17, 0, 6, "", "");

            AddMayorsPower(dt, 4, "ShockingTower", "震荡波塔", "", 10, 15, "", 18, 0, 6, "", "");
            AddMayorsPower(dt, 4, "Ballista", "大型弩车", "", 10, 15, "", 19, 0, 6, "", "");
            AddMayorsPower(dt, 4, "PowerPlant", "发电厂", "", 10, 15, "", 20, 1, 6, "", "");
            AddMayorsPower(dt, 4, "Executor", "机枪塔", "", 10, 15, "", 21, 1, 6, "", "");
            AddMayorsPower(dt, 4, "AdvancedQuarry", "高级采石场", "", 10, 15, "", 22, 1, 6, "", "");
            AddMayorsPower(dt, 4, "AdvancedFarm", "高级农场", "", 10, 15, "", 23, 1, 6, "", "");
            AddMayorsPower(dt, 4, "MillIron", "先进能源工坊", "", 10, 15, "", 24, 1, 6, "", "");
            AddMayorsPower(dt, 4, "RadarTower", "雷达", "", 10, 15, "", 25, 1, 6, "", "");
            AddMayorsPower(dt, 4, "WatchTowerStone", "石质哨塔", "", 200, 300, "", 26, 1, 6, "", "");
            AddMayorsPower(dt, 4, "WallStone", "石墙", "",1000, 2000, "", 27, 1, 6, "", "");
            AddMayorsPower(dt, 4, "GateStone", "石门", "", 50, 100, "", 28, 1, 6, "", "");
            AddMayorsPower(dt, 4, "OilPlatform", "采油平台", "", 10, 15, "", 29, 1, 6, "", "");

            AddMayorsPower(dt, 4, "Sawmill WoodGen", "锯木厂木头产量", "+", 45, 55, "", 1, 0, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 4, "StoneHouse WorkersSupply", "石屋提供工人", "+", 10, 15, "", 2, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 4, "StoneHouse GoldGen", "石屋金钱产量", "+", 250, 350, "%", 2, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 4, "HunterCottage FoodSupply", "猎人小屋提供食物", "+", 65, 75, "", 3, 0, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 4, "FishermanCottage FoodSupply", "捕鱼小屋提供食物", "+", 75, 85, "", 3, 0, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 4, "AdvancedFarm FoodSupply", "高级农场提供食物", "+", 105, 150, "", 3, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 4, "AdvancedQuarry ResourceCollectionCellValue", "高级采石场每单元资源收集值", "+", 380, 550, "%", 4, 1, 7, "+,-,=", "%");
            AddMayorsPower(dt, 4, "CommandCenter GoldGen", "指挥中心金钱产量", "+", 850, 1550, "", 5, 0, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 4, "CommandCenter ResourcesStorage", "指挥中心资源存储量", "+", 850, 1850, "", 5, 0, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 4, "MillIron EnergySupply", "先进能源工坊提供电力", "+", 150, 250, "", 6, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 4, "PowerPlant EnergySupply", "发电厂提供电力", "+", 250, 450, "", 6, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 4, "WallStone Life", "石墙生命", "+", 200, 350, "%", 7, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 4, "WatchTowerStone Life", "石质哨塔生命", "+", 200, 350, "%", 8, 1, 7, "+,-,=", ",%");
            AddMayorsPower(dt, 4, "OilPlatform OilGen", "采油平台石油产出", "+", 20, 30, "", 9, 1, 7, "+,-,=", ",%");

            _MayorsPowerTable = dt;
            SaveMayorsPowerTableXmlFile();
        }

        /// <summary>新增市长能力列表</summary>
        /// <param name="dt">需要新增的内存表</param>
        /// <param name="level">市长等级</param>
        /// <param name="name">能力名称</param>
        /// <param name="depict">描述</param>
        /// <param name="sign">加减运算符</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="dw">单位</param>
        /// <param name="isuse">是否起用</param>
        /// <param name="rstyle">奖励类型</param>
        /// <param name="sign_l">加减运算符限制，多个限制符使用小写逗号分隔</param>
        /// <param name="dw_l">单位限制，多个限制符使用小写逗号分隔</param>
        public static void AddMayorsPower(DataTable dt, int level, string name, string depict, string sign, int min, int max, string dw, int mtype, int isuse, int rstyle, string sign_l, string dw_l)
        {
            DataRow dr = dt.NewRow();
            dr["level"] = level;
            dr["name"] = name;
            dr["depict"] = depict;
            dr["sign"] = sign;
            dr["min"] = min;
            dr["max"] = max;
            dr["dw"] = dw;
            dr["mtype"] = mtype;
            dr["isuse"] = isuse;
            dr["rstyle"] = rstyle;
            dr["sign_limit"] = sign_l;
            dr["dw_limit"] = dw_l;
            dt.Rows.Add(dr);
        }

        /// <summary>保存市长能力内存表到文件</summary>
        public static void SaveMayorsPowerTableXmlFile()
        {
            string upath = GetMayorsPowerTableXmlFilePath();
            if (File.Exists(upath))
            {
                File.Delete(upath);
            }
            _MayorsPowerTable.WriteXml(upath, XmlWriteMode.WriteSchema);
        }

        /// <summary>另存市长能力内存表到文件</summary>
        /// <param name="path">另存路径</param>
        public static void SaveMayorsPowerTableXmlFile(string upath)
        {
            if (File.Exists(upath))
            {
                File.Delete(upath);
            }
            _MayorsPowerTable.WriteXml(upath, XmlWriteMode.WriteSchema);
        }

        /// <summary>返回市长能力内存表路径</summary>
        /// <returns>返回市长能力内存表路径</returns>
        public static string GetMayorsPowerTableXmlFilePath()
        {
            FileSys.NewDir(AppList.ConfigDir);
            return AppList.ConfigDir + AppList.MayorsPowerTableName + ".xml";
        }

    }
}
