use DiaryIdentity

insert into [DiaryIdentity].[dbo].[AspNetRoles](id, name, NormalizedName, ConcurrencyStamp)
values
('e64fa478-ff25-435e-b79a-e5bbe922991d',	'Student',	'STUDENT',	'bda2d77d-1c23-46e1-b54a-5d7b6153fc26'),
('3afa6efa-87c0-4ae3-a701-25269b31b268',	'Teacher',	'TEACHER',	'93e85b26-164b-4947-b53c-d6a876cf2836'),
('9fc84394-dcfc-4b64-a47a-0456fa85dd0e',	'Parent',	'PARENT',	'e80ee1f1-025d-42ea-9d49-1977acec6f06'),
('eac26752-1b7e-4714-a95d-5d0a853a6469',	'Admin',	'ADMIN',	'77e5e851-a1f1-4d87-b6ae-406be5039d53')

insert into [AspNetUsers] ('Id','UserName','NormalizedUserName','Email','NormalizedEmail','EmailConfirmed','PasswordHash','SecurityStamp','ConcurrencyStamp','PhoneNumber','PhoneNumberConfirmed','TwoFactorEnabled','LockoutEnd','LockoutEnabled','AccessFailedCount','Login')
values(N'362b92ef-6736-4bad-a368-93463a265969', N'parent1', N'PARENT1', NULL, NULL, 0, N'AQAAAAEAACcQAAAAELEmb8eRQey/RaE3UN6AHont4cqPPa+ITCuz79+7/BTRiGMtb9QRQzAuJh318fExLA==', N'HCP7R3KSS2PW5K723AAOPXTRLGAGZNTG', N'dc458ca7-a0a5-4aa5-8123-9804d6abfbc1', NULL, 0, 0, NULL, 1, 0, NULL),
(N'c2eb3b35-3b10-462b-a069-9079f3246076', N'teacher1', N'TEACHER1', NULL, NULL, 0, N'AQAAAAEAACcQAAAAEKizZdtunw7tjQCzeS3szp84WJ/aeL6XTjLzqy4l85I2OnPXvWfoQIsZNlSttrn9Xw==', N'UWIIWI2NI7VSSWFVFKSIX7JCMSRVRQE5', N'0810304b-f044-4f2a-bcf3-390cf56403c1', NULL, 0, 0, NULL, 1, 0, NULL),
(N'9772979e-81e0-4e75-9992-0887f9947856', N'parent2', N'PARENT2', NULL, NULL, 0, N'AQAAAAEAACcQAAAAENmk1a6zpwjybfloyLmxiBRFsWjLcpuX3addPyxAvKKYXvehcJ2bKrJzd4EbNWuC/g==', N'QMGERBF3QHITV6UGSMBGLZXOMYBEJAMH', N'5e88b96d-c8db-4ca6-ac7d-9ee8a41f6107', NULL, 0, 0, NULL, 1, 0, NULL),
(N'90fcadc8-f74b-4c27-a8eb-77815e9ecc7a', N'student2', N'STUDENT2', NULL, NULL, 0, N'AQAAAAEAACcQAAAAEKwyqJUf6wRKoDdOwWroXL+k1DdOKLylvJFS+ozBQ1Bovmzu1psfJGDJ0eQHjBBf2Q==', N'UYLKS4IWFZ6QTZ3NYEEB464IVUCPYC3K', N'994eaef5-c482-4c1f-9098-3283b5bf2c47', NULL, 0, 0, NULL, 1, 0, NULL),
(N'730c8edd-d7aa-4fef-b6a9-5cccc847ad99', N'student1', N'STUDENT1', NULL, NULL, 0, N'AQAAAAEAACcQAAAAEBxV780SeulK5vqEnC7GsCHBJjBio5BLM/zPO/40ANTjHYe6sdoN5JM0x/94wuGtSw==', N'Q7RDLTBWO6EA42LKEDHEB3BPUXI3AQY3', N'033605dd-055c-4f00-ae11-b91f233fb9e4', NULL, 0, 0, NULL, 1, 0, NULL),
(N'47251f1a-86eb-481d-867a-33468cf2e628', N'admin', N'ADMIN', NULL, NULL, 0, N'AQAAAAEAACcQAAAAED6c9N0wrjCiniOUgpQDIuGWcvBpd/Ba5MzgfdFGbv77+OBCgNamLi/EEbhMEC5Ynw==', N'CJIBHVLJ2HXM6UH5OLGLOIXNIBBMMXMR', N'ac98625a-3e59-4f0e-b77e-1f9feb0b8a67', NULL, 0, 0, NULL, 1, 0, NULL)

insert into [AspNetUserRoles] (userid, roleid)
values 
('c2eb3b35-3b10-462b-a069-9079f3246076','3afa6efa-87c0-4ae3-a701-25269b31b268'),
('362b92ef-6736-4bad-a368-93463a265969','9fc84394-dcfc-4b64-a47a-0456fa85dd0e'),
('9772979e-81e0-4e75-9992-0887f9947856','9fc84394-dcfc-4b64-a47a-0456fa85dd0e'),
('730c8edd-d7aa-4fef-b6a9-5cccc847ad99','e64fa478-ff25-435e-b79a-e5bbe922991d'),
('90fcadc8-f74b-4c27-a8eb-77815e9ecc7a','e64fa478-ff25-435e-b79a-e5bbe922991d'),
('47251f1a-86eb-481d-867a-33468cf2e628','eac26752-1b7e-4714-a95d-5d0a853a6469')