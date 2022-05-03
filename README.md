# EfCoreTutorial

![image](https://user-images.githubusercontent.com/49749125/164887227-827a2123-7568-4030-8762-a1893bef77c9.png)
![image](https://user-images.githubusercontent.com/49749125/164887242-a41ececf-6fcb-4540-9e83-3d4708edc7eb.png)
![image](https://user-images.githubusercontent.com/49749125/164887249-d5524820-a7af-4a21-b697-b28f5f78ce86.png)
![image](https://user-images.githubusercontent.com/49749125/164887259-078f2b2e-b7c8-43d3-b7af-5624dfa848fe.png)
![image](https://user-images.githubusercontent.com/49749125/164887283-584478ae-445f-458f-81f5-9eb51a04163c.png)
![image](https://user-images.githubusercontent.com/49749125/164887292-8a0de8b8-3a0a-4a69-a4b1-21f21f53c01b.png)
![image](https://user-images.githubusercontent.com/49749125/164887314-a3b6a5dc-a5da-4cdc-a09b-d91e9bf5f48b.png)

> #### Not : Yukardaki ilk 5 i Relational Database ' dir. Siz EF Core ile örneğin bir NoSql bir DB ye bağlantı sağlayamazsınız. Çünkü EF Core Relational olmayan Database ler ile bir bağlantısı yok. 

> #### Örn MongoDB yi EF Core ile kullanamazsınız. Bu noktada bir MongoDB ye bağlanmak istediğinizde MongoDB nin .Net için yazılmış olan library lerini kullanıyoruz.

> #### Non Relational olarak çalışabildiği tek DB istisnai olan InMemory database ' dir. Bu zaten .Net e özgü bir database olarak düşünebiliriz.

> #### Diğerleri dataları fiziksel bir yere kaydederken InMemory tüm dataları memory de tutar. Bu da özellikle test senaryolarında hızlı sonuc almak adına kullanılabilir.

![image](https://user-images.githubusercontent.com/49749125/164888255-7fc8158e-cd32-4cc1-9e5a-f0f78f680adf.png)

![image](https://user-images.githubusercontent.com/49749125/164888322-d4f33fe7-b832-45a8-bee6-372b5a432ae8.png)

> #### Database First de bir tablo olusturmak istiyorsam gidip bunu DB de olusturuyorum daha sonra o tabloya karsılık gelecek class ımı ve DbSet imi olusturacağım.

> #### Tabi burda şöyle bir alternatif de var `Scaffolding Komutları` ile de DB de olusturdugumuz tabloların karısılıklarını kod tarafında olusturabiliriz ama bunun bir iki tane dezavantajıda da bunlardan bahsedeceğiz ilerde. 

> #### Entity dendiği zaman bu bir database de bir tabloya karsılık gelen bir class dan bahsediyor şeklinde aklınıza gelmeli.

![image](https://user-images.githubusercontent.com/49749125/164888491-6daf0e55-6327-4e08-bec0-80f3aa981ada.png)

> #### CodeFirst de ise `Migration` toolu ve komutları ile kodda ile olusturdugumuz class lara karsılık gelen Database tablolarını otomatik olarak olusturacagız.

##  `DatabaseFirst` 

![image](https://user-images.githubusercontent.com/49749125/164890392-425b0a88-15ba-46d2-af57-68da7b1fdcc5.png)
![image](https://user-images.githubusercontent.com/49749125/164890507-3c57d175-7f8b-47d4-8b50-94443feabb1e.png)

> #### Database tablomuzu olusturalım.

![image](https://user-images.githubusercontent.com/49749125/164891016-b6709eba-a086-4bc3-9b96-1daa102b0542.png)
![image](https://user-images.githubusercontent.com/49749125/164891128-d6eb086a-e28a-4ce3-a031-d634591e1d67.png)

> #### `DAL` adında bir Folder olusturalım. İlk olarak bir `DbContext` sınıfı olusturacagız. 

> #### Normalde `EFCore` library sinden gelen bir `DbContext` sınıfımız var bizim olusturacagımız class ondan inheritance alacak. 

> #### `DbContext` reserved keyword oldugundan biz kendi DbContext sınıfımıza bundan farklı bir isimlendirme yapalım. `AppDbContext` diyelim.

![image](https://user-images.githubusercontent.com/49749125/164891911-30e3e4fa-592d-4546-a426-e2966ab4b164.png)

> #### Kısaca DbSet deki props name ile veritabanındaki table name aynı ise EF Core otomatik olarak bunları eşleştirir.

> #### Eğer farklı isimler ise onun içinse yapılacak configurationları birazdan anlatacağız.

![image](https://user-images.githubusercontent.com/49749125/164892063-e12ffacd-5dfe-46f6-a4fe-52b328796d69.png)

> #### ÖNEMLİ : Artık Product class ına Entity diyebiliriz zira AppContext içerisinde DbSet<> ile Product class ını kullanarak bir prop tanımladım yani artık bu Database de bir tabloya karsılık geliyor demektir ki o zaman bu bir Entity dir diyebiliriz.

![image](https://user-images.githubusercontent.com/49749125/164893564-4bd7d2ad-7a55-425f-b9f7-94946208374f.png)

![image](https://user-images.githubusercontent.com/49749125/164893627-7c276870-43cc-435f-ba4e-9f8c303d079e.png)

![image](https://user-images.githubusercontent.com/49749125/164893678-7f25f5d1-b780-40b8-a3c1-1cb200feea0c.png)
![image](https://user-images.githubusercontent.com/49749125/164893725-ec83e984-e0b9-4f49-8cb3-64d8e17b0750.png)
![image](https://user-images.githubusercontent.com/49749125/164893765-00a72694-5f16-4427-8921-1f66c4cb54fa.png)
![image](https://user-images.githubusercontent.com/49749125/164893819-bcbb879b-df54-447e-b35b-0b1ef5a381e6.png)
![image](https://user-images.githubusercontent.com/49749125/164893956-d2110c44-29c1-42ce-b8c3-ee0f9ad51670.png)
![image](https://user-images.githubusercontent.com/49749125/164894019-d7dd4f9d-ebef-4642-b808-1b7d15fd4758.png)
![image](https://user-images.githubusercontent.com/49749125/164894064-6a74553d-36f9-4ec7-9d56-c5e1077730d9.png)
![image](https://user-images.githubusercontent.com/49749125/164894111-f0c99c7a-94af-47f4-a1f8-3b7ec7a6fe79.png)
![image](https://user-images.githubusercontent.com/49749125/164894211-148b8d7b-c332-4ca2-8f8a-5458aeec81a3.png)
![image](https://user-images.githubusercontent.com/49749125/164894384-46a481ce-0c91-4396-9df3-f7ec0b4254db.png)
![image](https://user-images.githubusercontent.com/49749125/164894509-e498f26d-7ea2-42d5-8c28-ca086c4f6fc8.png)
![image](https://user-images.githubusercontent.com/49749125/164894637-95962bbd-1d8c-4822-b645-79f2d2cc150a.png)
![image](https://user-images.githubusercontent.com/49749125/164894786-38365448-d7e1-4c55-b0fb-9a7f6ea0f77a.png)
![image](https://user-images.githubusercontent.com/49749125/164894879-26e92798-5247-4906-b145-d8670316c6aa.png)
![image](https://user-images.githubusercontent.com/49749125/164894943-dede3ecc-766f-4fb6-b0f0-3214d4f481cf.png)
![image](https://user-images.githubusercontent.com/49749125/164895068-d493b9f6-c349-4ec0-bbde-2d89ff8787ba.png)
![image](https://user-images.githubusercontent.com/49749125/164895013-2cfad7fa-21c8-4876-b322-f3bbdbff2da2.png)
![image](https://user-images.githubusercontent.com/49749125/164895338-88956ff5-fdec-4190-a6ad-641ef03641b9.png)
![image](https://user-images.githubusercontent.com/49749125/164895604-483f22f7-fcc4-45af-9e33-c967f503181f.png)
![image](https://user-images.githubusercontent.com/49749125/164896105-49ea8f7c-555c-48bf-927c-42da1e29ec9b.png)
![image](https://user-images.githubusercontent.com/49749125/164896229-f9bcac5b-9b6c-43fc-98f7-ed1390e899cf.png)
![image](https://user-images.githubusercontent.com/49749125/164896802-c3d81fdb-335d-4244-85a8-8ccf098bd433.png)
![image](https://user-images.githubusercontent.com/49749125/164896944-255845bd-c2d0-4773-a544-86a2bbd951fb.png)
![image](https://user-images.githubusercontent.com/49749125/164896983-a7daafb1-9b36-4165-973e-23053d0d003e.png)
![image](https://user-images.githubusercontent.com/49749125/164897763-b8187dd7-b03a-40a7-b553-661be12b532b.png)
![image](https://user-images.githubusercontent.com/49749125/164900929-645093cd-11d2-4d9c-adb1-057ffb4c1ffd.png)
![image](https://user-images.githubusercontent.com/49749125/164903607-be27e7f2-2e53-45e8-9f27-1dd72df17dd9.png)
![image](https://user-images.githubusercontent.com/49749125/164909937-5f1bdae6-e8bb-4fbb-92f6-1c8b8f111455.png)
![image](https://user-images.githubusercontent.com/49749125/164910376-c163ddbc-7098-4fdf-b144-3dbac6a626f2.png)

### Database First İle Olusturulan Tablolarda Değişiklikler Yapmak

### 1. Manuel Yol

![image](https://user-images.githubusercontent.com/49749125/164911990-a3f06084-69e5-49b3-ab02-ac0f603c5ac3.png)
![image](https://user-images.githubusercontent.com/49749125/164912036-4407992b-d9da-4953-b2e4-fbac43e8b580.png)
![image](https://user-images.githubusercontent.com/49749125/164912118-6a0e55e3-d9d7-4450-8cf2-6073c9b23e03.png)
![image](https://user-images.githubusercontent.com/49749125/164912239-1b3f303f-0ca2-4ec2-a0bd-739aa844dd52.png)


### 2. Scaffolding ile

![image](https://user-images.githubusercontent.com/49749125/164912571-5b118e91-b782-4fc1-9e00-a3933435f874.png)
![image](https://user-images.githubusercontent.com/49749125/164971353-ab04288d-2bb4-4d5f-82bf-1ec21c9c09a1.png)
![image](https://user-images.githubusercontent.com/49749125/164971725-f4a8b20e-3fc6-4c44-8f27-f2bf7ea5a92a.png)
![image](https://user-images.githubusercontent.com/49749125/164971856-55503802-6bdb-4203-a2cf-51a09149c8a3.png)
![image](https://user-images.githubusercontent.com/49749125/164971959-ce0d4b5d-10f0-4ecf-8ff0-256ef86fdbb1.png)

##  `CodeFirst`

![image](https://user-images.githubusercontent.com/49749125/164972369-d84f87ad-4f4a-42dc-a659-f7c9146e0c74.png)
![image](https://user-images.githubusercontent.com/49749125/164974192-07c6fd8b-7871-4ee6-8dbc-ce5463770cd1.png)
![image](https://user-images.githubusercontent.com/49749125/164974747-9ca13ea0-c3c6-4960-80f0-772413139e46.png)
![image](https://user-images.githubusercontent.com/49749125/164974849-65a4d163-0ddc-4fb1-a2cc-f8622eefeb29.png)
![image](https://user-images.githubusercontent.com/49749125/164978028-96eb6f0f-a526-4f4f-ba9c-747450287835.png)
![image](https://user-images.githubusercontent.com/49749125/164978009-db8161c7-ae4d-4572-ad1a-7a861ee99fdd.png)
![image](https://user-images.githubusercontent.com/49749125/164978020-111fa273-b893-41f9-b689-0585ebf7cc5e.png)
![image](https://user-images.githubusercontent.com/49749125/164977995-1d1e7f4e-710f-4945-ad3b-3c7d02d009f4.png)
![image](https://user-images.githubusercontent.com/49749125/164978336-5ecd2c24-9ef9-4dc6-828e-dab0b6055f65.png)

### `Migration Is Hero`
![image](https://user-images.githubusercontent.com/49749125/164978409-b346ea09-7775-4e8f-90d4-41938062de5b.png)
![image](https://user-images.githubusercontent.com/49749125/164980710-8739174e-fca2-47e8-b19b-d2c3f76c3564.png)
![image](https://user-images.githubusercontent.com/49749125/164981348-2250e1bd-6960-42ce-b613-9eff7dfbf714.png)
![image](https://user-images.githubusercontent.com/49749125/164981393-85fd2829-a00c-4bf1-8c04-30aded8626e8.png)
![image](https://user-images.githubusercontent.com/49749125/164981475-ea4964a6-9383-492b-8c29-067b23a3475b.png)
![image](https://user-images.githubusercontent.com/49749125/164981679-0732efa6-fe49-4f84-80ce-2b08100e88c0.png)
![image](https://user-images.githubusercontent.com/49749125/164981866-eccdb9a6-49cf-472a-b8da-f2d8c8d073d0.png)
![image](https://user-images.githubusercontent.com/49749125/164982291-92c8409b-11be-4b20-b99a-1c41c149592b.png)
![image](https://user-images.githubusercontent.com/49749125/164982680-9193e45a-c743-4354-81f2-d1fa7e2e5764.png)
![image](https://user-images.githubusercontent.com/49749125/164982787-a7903593-373a-4017-abd0-dc33f25e48e7.png)
![image](https://user-images.githubusercontent.com/49749125/164982858-c4df8e18-457e-4593-8df7-6291e99d4bd8.png)
![image](https://user-images.githubusercontent.com/49749125/164982962-5e0ef7d3-60d5-4599-a368-b78f74a1991c.png)
![image](https://user-images.githubusercontent.com/49749125/164983426-5dcdd474-6f7e-4aa4-8022-a6db043e155c.png)
![image](https://user-images.githubusercontent.com/49749125/164983686-d4a45252-6325-4b78-8288-e17db3ed3886.png)
![image](https://user-images.githubusercontent.com/49749125/164983900-869eaa7a-f221-4c51-bcca-9916368e0327.png)
![image](https://user-images.githubusercontent.com/49749125/164983991-c9393ba3-392e-4c30-b404-166cc3bc86ca.png)

### `Migration Is RockStar`
![image](https://user-images.githubusercontent.com/49749125/164984056-a9497303-40f9-413a-bd2c-c818e2c1fb29.png)
![image](https://user-images.githubusercontent.com/49749125/164985681-1c768e0f-375a-4624-9094-faf0d6a07d54.png)

#### `Senaryo 1` --> `Hatalı bir migration olusturdum bunu 'update-database' komutu ile db ye yansıtmadan farkettim bu migration ı nasıl geri kaldırırım?`
![image](https://user-images.githubusercontent.com/49749125/165047750-958d1e66-2316-4f5d-8d6a-5613869ed571.png)
![image](https://user-images.githubusercontent.com/49749125/165047986-81f7f06e-3326-4daf-a859-2405b2d54dcc.png)
![image](https://user-images.githubusercontent.com/49749125/165048420-46bf9f35-a5b6-40d2-8529-58ae0dce01b9.png)
![image](https://user-images.githubusercontent.com/49749125/165049230-9f53462b-a964-4c90-9a39-cee1710acf7c.png)
![image](https://user-images.githubusercontent.com/49749125/165049546-6a5ae4d3-a977-4b90-86e8-899ffaec6ac2.png)


#### `Senaryo 2` --> `Hatalı bir migration olusturdum bunu 'update-database' komutu ile db ye yansıttım ve sonra farkettim bu migration ı nasıl geri kaldırırım?`
![image](https://user-images.githubusercontent.com/49749125/165057455-f40dfb3a-ae54-489b-8dc6-f715d31f608d.png)
![image](https://user-images.githubusercontent.com/49749125/165057651-5b0f7180-030c-451e-9c72-b87bd0bd40f0.png)
![image](https://user-images.githubusercontent.com/49749125/165059682-70ec984d-f6ac-4c79-9c0f-4ec38889ae0b.png)
![image](https://user-images.githubusercontent.com/49749125/165059879-bfcfe082-58f3-4732-9fe0-a8c6c218553a.png)
![image](https://user-images.githubusercontent.com/49749125/165060849-fa307002-c25f-4ab1-b22c-2e643e5ba1d7.png)
![image](https://user-images.githubusercontent.com/49749125/165062545-7beb7222-b57e-4869-8a2c-d4c3c76c6f2a.png)
![image](https://user-images.githubusercontent.com/49749125/165065487-955828c7-31ba-42be-b47c-fa48d62021a5.png)
![image](https://user-images.githubusercontent.com/49749125/165065960-3ea78d25-19c9-4c86-8604-bc87a4395d65.png)

#### `Script Migration`
![image](https://user-images.githubusercontent.com/49749125/165067039-08ec85a4-46de-49f2-a07b-fc111b9c08c8.png)

### `EntityFrameworkCore 2. Kısım`

### `DbContext`

![image](https://user-images.githubusercontent.com/49749125/166102349-e23f3d31-7125-4a24-8cfb-25fdc4c2bc0c.png)
![image](https://user-images.githubusercontent.com/49749125/166102721-6964368e-988b-4061-8dca-161f44349044.png)
![image](https://user-images.githubusercontent.com/49749125/166102966-d43c29bb-2605-4aa4-b4b9-2ab9f935508d.png)
![image](https://user-images.githubusercontent.com/49749125/166103841-993af861-bafb-4d9c-921d-5d5e1b93bb0c.png)
![image](https://user-images.githubusercontent.com/49749125/166103916-2dcc55f8-dc2b-4059-b321-549be605bb4e.png)
![image](https://user-images.githubusercontent.com/49749125/166105341-9b1d49d7-ed9e-4289-a422-e060e29be4df.png)
![image](https://user-images.githubusercontent.com/49749125/166105632-f0d5515f-6d1f-4695-93d5-617448e4b2fd.png)
![image](https://user-images.githubusercontent.com/49749125/166106512-2f71f8be-5bc1-49c9-8b2a-0a7202d8cc19.png)
![image](https://user-images.githubusercontent.com/49749125/166106633-8b4aca95-a5df-4d69-a501-cb2e7a0a40bf.png)
![image](https://user-images.githubusercontent.com/49749125/166107764-e63d568e-7f0c-4b93-97d5-ba042d7e175d.png)
![image](https://user-images.githubusercontent.com/49749125/166108483-22429d45-8c8e-43e6-a4ad-986986252e7e.png)
![image](https://user-images.githubusercontent.com/49749125/166108792-0783bff4-6142-4c03-b4a9-c67ab37597f9.png)
![image](https://user-images.githubusercontent.com/49749125/166109910-7024b413-08bf-457a-bd3a-8a14e24f4c81.png)
![image](https://user-images.githubusercontent.com/49749125/166110373-7918ee41-a9f1-4b6d-8d3a-70ac30da88cb.png)
![image](https://user-images.githubusercontent.com/49749125/166436070-df20cd2a-c8b2-4ea6-b37d-1728e815fd94.png)
![image](https://user-images.githubusercontent.com/49749125/166440164-6b176335-b20c-4155-b521-6d3fd91c92c5.png)
![image](https://user-images.githubusercontent.com/49749125/166442122-c3749673-e542-4bdb-a9b1-7d20bca45f83.png)
![image](https://user-images.githubusercontent.com/49749125/166442871-65fc0593-cfe8-4bb6-b03a-614f53d7951c.png)
![image](https://user-images.githubusercontent.com/49749125/166446033-c0d7dc2f-bb50-4d2a-bf38-0a9644fc4ece.png)
![image](https://user-images.githubusercontent.com/49749125/166487186-5434050f-367d-4225-912c-87d63fffa453.png)
![image](https://user-images.githubusercontent.com/49749125/166487694-fbfe9d32-1c2c-4b49-8228-55287d031c6c.png)
![image](https://user-images.githubusercontent.com/49749125/166492228-689d6da8-b2e4-47af-b2d6-925bca4c297a.png)

### `DbSet`

![image](https://user-images.githubusercontent.com/49749125/166492644-c1981a62-a5d3-4080-9542-bee9297849ed.png)
![image](https://user-images.githubusercontent.com/49749125/166500415-ec90e8ee-15b9-456f-958f-46587b5afd76.png)


`` 
