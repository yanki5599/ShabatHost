use shabat;

create table Guests(
	ID int primary key identity,
	name nvarchar(20) unique
);

create table Categories(
	ID int primary key identity,
	name nvarchar(20) unique
);


create table Food(
	ID int primary key identity,
	Guest_ID int foreign key references Guests(ID),
	Category_ID int foreign key references Categories(ID),
	name nvarchar(20),
	constraint AK_CatFoodGuest unique(Guest_ID,Category_ID,name)
);



use master;
begin Transaction 

	declare @dbName		nvarchar(20) = 'shabat';
	declare @Guests		nvarchar(20) = 'Guests';
	declare @Categories nvarchar(20) = 'Categories';
	declare @Food		nvarchar(20) = 'Food';

	begin try
	
		IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = @dbName)
		begin
			DECLARE @sqlCreateDatabase NVARCHAR(MAX)
			SET @sqlCreateDatabase = 'CREATE DATABASE ' + QUOTENAME(@dbName)
			EXEC(@sqlCreateDatabase);
		end
		DECLARE @sqlUes NVARCHAR(MAX) = 'USE ' + QUOTENAME(@dbName);
		EXEC(@sqlUes);
		
		IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = @Guests AND type = 'U')
        BEGIN
			create table Guests(
				ID int primary key identity,
				name nvarchar(20) unique
				);
		END

		IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = @Categories AND type = 'U')
        BEGIN
				create table Categories(
					ID int primary key identity,
					name nvarchar(20) unique
				);
		END

		IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = @Food AND type = 'U')
        BEGIN
			create table Food(
				ID int primary key identity,
				Guest_ID int foreign key references Guests(ID),
				Category_ID int foreign key references Categories(ID),
				name nvarchar(20),
				constraint AK_CatFoodGuest unique(Guest_ID,Category_ID,name)
			);
		END
		commit transaction;
	end try

	begin catch
		print 'error';
		rollback transaction;
	end catch


	select * from Categories;


	

