using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Speech.Recognition.SrgsGrammar;

namespace Silicon_Library.Core.Helpers;
public class DbRepository
{
    private  IDbConnection _db;
     public DbRepository()
    {
        _db = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Sandeep V\\source\\repos\\Silicon-Library\\Silicon Library\\Assets\\Database\\Database.mdf; Integrated Security=True;Connect Timeout=30");
    }
    public void SaveRecord(Records records)
    {
        _db.Open();
        var sql = @"INSERT INTO Records 
([UserId],[Username],[DeviceId],[DeviceName],[DeviceCondition],[DateReg],[DateDue])
VALUES (@UserId,@Username,@DeviceId,@DeviceName,@DeviceCondition,@DateReg,@DateDue);";

        using (var connection = _db)
        {
            var Response = connection.Execute(sql,records);
        }
        _db.Close();
    }
    public IEnumerable<Records> GetInventoryList()
    {
        IEnumerable<Records> inventoryAudits = new List<Records>();
        _db.Open();
        var sql = @"SELECT [UserId],[Username],[DeviceId],[DeviceName],[DeviceCondition],[DateReg],[DateDue] FROM Records";
        inventoryAudits = _db.Query<Records>(sql);
        _db.Close();
        return inventoryAudits;
    }
    public IEnumerable<DeviceDetails> GetDeviceList()
    {
        _db.Open();
        var sql = @"select * from Devices";
        var devices = _db.Query<DeviceDetails>(sql);
        _db.Close();
        return devices.ToList();
    }

}

public class Records
{
    public int Sno
    {
        get; set;
    }
    public string UserId
    {
        get; set;
    }
    public string Username
    {
        get; set;
    }
    public int DeviceId
    {
        get; set;
    }
    public string DeviceName
    {
        get; set;
    }
    public bool? DeviceCondition
    {
        get; set;
    }
    public DateTime? DateReg
    {
        get; set;
    }
    public DateTime? DateDue
    {
        get;set;
    }
}

public class DeviceDetails
{
    public int SNo
    {
        get; set;
    }
    public string  DeviceName
    {
        get; set;
    }
    public string DeviceIcon
    {
        get; set;
    }
    public string CLIPath
    {
        get; set;
    }
}
