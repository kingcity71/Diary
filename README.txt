1. Создание миграций БД
dotnet ef migrations add Initial --context IdentityContext --project MedClinic.Data --startup-project MedClinic
dotnet ef migrations add Initial --context MedClinicContext --project MedClinic.Data --startup-project MedClinic

2. Применение
dotnet ef database update --context IdentityContext --project MedClinic.Data --startup-project MedClinic
dotnet ef database update --context MedClinicContext --project MedClinic.Data --startup-project MedClinic

3. Запустить скрипты из папки assets\DevOps\
	- Specializations.sql
	- Properties.sql