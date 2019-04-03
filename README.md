D:\test\DynamicSettingsSln\EntityFramework\CodeFirst\DynamicSettings.CodeFirst.Context>dotnet ef migrations add V1 -s ../../../Web/DynamicSettings.API
Done. To undo this action, use 'ef migrations remove'

D:\test\DynamicSettingsSln\EntityFramework\CodeFirst\DynamicSettings.CodeFirst.Context>dotnet ef database update -s ../../../Web/DynamicSettings.API
Done.


D:\test\DynamicSettingsSln\Web\DynamicSettings.API>dotnet ef migrations add V1
Done. To undo this action, use 'ef migrations remove'

D:\test\DynamicSettingsSln\Web\DynamicSettings.API>dotnet ef database update
Done.


DBFirst:
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools

Scaffold-DbContext "Data Source=.;Initial Catalog=Blogging;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
Scaffold-DbContext "数据库连接字符串" EF组件名(Microsoft.EntityFrameworkCore.SqlServer/Pomelo.EntityFrameworkCore.MySql/等等) -OutputDir 输出文件夹名称



Updated Note
20190227:CodeFirst、Architecture、Configuration
20190228:Session->Redis、Redis、DBFirst
20190301:


添加.gitingore到\DynamicSettingsSln\.git\info文件夹

git clone https://github.com/sxliupeng/DynamicSettings.git
git status
git diff
git add .
git reset head .
git commit -m "Initial"
git push

Redis
D:\Redis\Redis-x64-3.2.100>redis-server.exe redis.windows.conf



