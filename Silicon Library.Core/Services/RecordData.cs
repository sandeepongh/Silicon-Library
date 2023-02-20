using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Silicon_Library.Core.Helpers;

namespace Silicon_Library.Core.Services;
public class RecordData
{
    public IEnumerable<Records> GetRecordData(int SNO=1)
    {
        DbRepository dbRepository=new DbRepository();
        return dbRepository.GetInventoryList();
    }
}