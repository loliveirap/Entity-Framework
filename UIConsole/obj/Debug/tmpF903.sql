DECLARE @CurrentMigration [nvarchar](max)

IF object_id('[dbo].[__MigrationHistory]') IS NOT NULL
    SELECT @CurrentMigration =
        (SELECT TOP (1) 
        [Project1].[MigrationId] AS [MigrationId]
        FROM ( SELECT 
        [Extent1].[MigrationId] AS [MigrationId]
        FROM [dbo].[__MigrationHistory] AS [Extent1]
        WHERE [Extent1].[ContextKey] = N'UIConsole.DBProduto'
        )  AS [Project1]
        ORDER BY [Project1].[MigrationId] DESC)

IF @CurrentMigration IS NULL
    SET @CurrentMigration = '0'

IF @CurrentMigration < '201402220200133_InitialCreate'
BEGIN
    CREATE TABLE [dbo].[Produtoes] (
        [Id] [int] NOT NULL IDENTITY,
        [Nome] [nvarchar](max),
        CONSTRAINT [PK_dbo.Produtoes] PRIMARY KEY ([Id])
    )
    CREATE TABLE [dbo].[__MigrationHistory] (
        [MigrationId] [nvarchar](150) NOT NULL,
        [ContextKey] [nvarchar](300) NOT NULL,
        [Model] [varbinary](max) NOT NULL,
        [ProductVersion] [nvarchar](32) NOT NULL,
        CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
    )
    INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
    VALUES (N'201402220200133_InitialCreate', N'UIConsole.DBProduto',  0x1F8B0800000000000400CD564D73DA3010BD77A6FFC1A3537B2822E4D2664C3209844EA6053231C95DD80B68AA0FD79233F0DB7AE84FEA5FE80A7F6203A1690FBDD9F2DBDDB74F4F6BFDFAF1D3BF5A4BE13D4362B8567D72D6E9120F54A823AE967D92DAC5878FE4EAF2ED1BFF36926BEFA9C09D3B1C462AD3272B6BE30B4A4DB802C94C47F230D1462F6C27D492B248D35EB7FB899E9D51C0140473799EFF902ACB256C5FF075A05508B14D9918EB0884C9D7F14BB0CDEA4D980413B310FAE4F10ED1460B20DEB5E00C09042016C4634A69CB2CD2BB783410D844AB6510E30213B34D0C885B306120A77D51C14FEDA0DB731DD02AF0550A90B237ECEE1655B01B476FDB619FDC273A4AADAE8310F605363B0BB884C01812BB7980451E7A17118FEEC6D1666019568B71D5F149D9F31EF126A9106C2EA014ABA66A6075029F4141C22C44F7CC5A4894CB01DB2E5AD51BB5265A42510D7707FD45BC315B7F05B5B4AB3EC147E28DF81AA2622567F0A838DA11836C92C26E119F5602B665459B58C6916E4E6078B35FDD0C1D80DDDD0343BC2A7B66B24E91602F8BB25EE55E9AD9B7B0393DE0737FCCE21805A9F93E5FF182CCF4830FC19FBB4D66396868F698AE645B56C2ED654B687CC5D2C874C4136387CCB239735B3288640BF6A2BA459D86C84D63579A1701EE390B2A8F7E676FADBA7023EC45A231B76D4149E2C009CB6383900996EC3923032D52A90E9DB363D199EBEBF1D94A3B834F1BD49BCAD096348DD3DE94FA98479B90B27AE9D58627FDDC1F2F0FE896613208F1509A671E39B3041B6341761CA0137C1703C1B1DF0A30668A2FC0D899FE0638617ADDB35E63D8BF62F0526322F19F4E5FEEBA7F71BEB686F3E903573DB3245CB1E49D64EBF7F54C7F3B54DBD3E1A4E17A6CB66676E993688E2FB38C66FE11CCAB476FDBBE3EADDF42FC2118BEAC52B83B8982D0FDF9AAA405E64E2D74A136F6566754401A9B3106CB2294E83AB17CC1428B9F433066FB177C622245C8AD9C4374A7A6A98D537B6D0CC8B9D8F9ABFAF478FDEDFF6597B33F8DDD9BF9172D204D8E2DC054DDA45C4425EF51DB8C875238B7E40E4756780BC074CB4D9969A2D5898972F986108372E76306321698CC4C55C09EE130B79735DC55CC1F72B64C9834798E2ADE5D8AA9BB155FFE063FF07EE3470B0000 , N'6.0.2-21211')
END

IF @CurrentMigration < '201402220254243_AdicionadoCategoria'
BEGIN
    ALTER TABLE [dbo].[Produtoes] ADD [Categoria] [nvarchar](max)
    INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
    VALUES (N'201402220254243_AdicionadoCategoria', N'UIConsole.DBProduto',  0x1F8B0800000000000400CD57CD6ED34010BE23F10ED69EE040360D17A81C50495A5441DA0AB7DC27F6245DB13FC6BBAE9267E3C023F10ACCC6BFB19326AD3870B3D733DF7CF3EDCCCEFACFAFDFE1C79592C1036656183D662783210B50C726117A3966B95BBC79C73E7E78F9223C4FD42AF85ED9BDF576E4A9ED98DD3B979E726EE37B5460074AC499B166E106B1511C12C347C3E17B7E72C2912018610541F82DD74E28DCBCD0EBC4E8185397839C9904A52DD7E94BB4410DAE40A14D21C631BBBB246B6B24B2E04C0A200211CA050B406BE3C011BDD33B8B91CB8C5E46292D80BC5DA748760B90164BDAA78DF9B1190C473E03DE383E4B0156E746D99D930A6EEDE96D321CB39BCC24B9336D2332FB82EBAD055A22C31433B7FE868BD2F5326101DFF6E35DC7DAADE5E3A3D393766F472CB8CAA584B9C45AAC96AA9133197E468D19384C6EC039CCB4C7C04D16BDE89D58574661158D7687EA8B0533587D45BD74F763468F2CB8102B4CAA9592C19D16548EE4E4B21C0F059910B5A5C904FCE348216FB6AABF8154900E040953B2987EDABD8F8575846E7BB72D0B1AF4A29C0715C04E1675BCA64F78D1285543F13D1D15CE204D49905687952B4154B4D7E44DF4F4BA5605068FED8EF2AED9D691A89060899DAF149A985E88CCBA29389883DF9249A27A6607D5ADE27444EEB650A379E5E09F0BA7FA9019EC8CD516EE827251D4029BB4B026B1A7974BDF280609D98E6E9C18992BBDAFA31FF32EFAABED5FAC1C8FD06A9E364C6BB98F15F28E0C5D95794FE6CE19D5DDB6C7EABD6B5247AFEBBE53DF61596B87C74AAFF80A131690480F22F18517ADAD4335F00683E8A79C4841F9360633D06281D6DD9A1F48E7E2687832EA8CA8678C0B6E6D22FFD399217CF607A7426FA41C3F26F40364F13D64AF14AC5EB7919E350A9E80F6B4E3BE7F6E1D75EC3F76EA17C53766C99C5E6E0B9AE547B4CF1E0AFD660879FB26164ED18A6503E1EF651A633FFD1BD0CAE6522F4C2539E5D6665499747664860E1292E82C736201B1A3CF315ABB99CFDF41E66472AEE6985CEAEBDCA5B93BB316D55C6EDD2C42FE78FCCDE4DBE61C5EA7FECDFE8B1488A6A014F05A7FCA854C6ADE17FDD2DE07E1ABA5EC176245F7135FA7EB1AE9CAE823814AF9A698A2F6DD768B2A950466AF75040FB89FDB610DB7150BA7029619285B6234FEFEC780FB3F830F7F0156D1A93C4B0C0000 , N'6.0.2-21211')
END

