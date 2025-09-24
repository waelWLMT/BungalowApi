command pour la migration et la mise à jour de la bdd
Add-Migration InitialCreate -Project WLMT.Bungalows.Infrastructure -StartupProject WLMT.Bungalows.Api -OutputDir Persistence/Migrations
Update-Database -Project WLMT.Bungalows.Infrastructure -StartupProject WLMT.Bungalows.Api
