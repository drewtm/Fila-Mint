using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtruderController
{
    enum MessageType
    {
        CMD_GET_STATUS = 30,
        RSP_GET_STATUS = 31,

        CMD_SET_TEMPS = 32,
        RSP_SET_TEMPS = 33,

        CMD_GET_SETTEMPS = 34,
        RSP_GET_SETTEMPS = 35,

        CMD_STORE_SETTEMPS = 36,
        RSP_STORE_SETTEMPS = 37
    };
}
