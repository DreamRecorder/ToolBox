using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DreamRecorder.ToolBox.TelegramBot;

public interface ITelegramIdUserProvider <out TUser> where TUser : IUser
{

	TUser GetUser ( long telegramId );

}
