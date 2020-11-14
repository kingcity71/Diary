1. Создание миграций БД
dotnet ef migrations add Initial --context IdentityContext --project Diary.Identity --startup-project Diary.WebApp
dotnet ef migrations add Initial --context Context --project Diary.Data --startup-project Diary.WebApp

2. Применение
dotnet ef database update --context IdentityContext --project Diary.Identity --startup-project Diary.WebApp
dotnet ef database update --context Context --project Diary.Data --startup-project Diary.WebApp

3. Запустить скрипты из папки Start Helper