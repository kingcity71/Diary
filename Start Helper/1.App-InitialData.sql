use Diary

delete from users
delete from Properties
delete from PropertyValues
delete from ChildParents
delete from Subjects
delete from Classes
delete from ClassStudents

insert into users (id,login, userrole)
values
('D9FBA6B5-EEA2-4298-960D-AFC925E76327','admin',3),
('64CD0FD2-4335-4094-A763-ED0CB40222C3','student1',0),
('1810BDDC-2D6D-4FF0-8DA4-7FDBA7B5E5AC','student2',0),
('494FEC84-4034-4402-817C-A67F1C484528','parent1',1),
('72D7E193-9781-4E42-8858-C1AE94456190','parent2',1),
('B3FBA83F-C854-4486-B12F-C913307DBC72','teacher1',2),

('{13721765-B6B8-4D37-8A2E-8D390DBBCD16}','student3',0),
('{BE9AEF15-A5F0-42D6-8A71-FAE913E87986}','student4',0),
('{61F2A74E-E889-4142-9627-5340F1195196}','parent3',1),
('{FF93CC19-6DC5-491F-96B2-6A6305A85241}','parent4',1)

insert into Properties (id,name,Type,ForUserRole,Required)
values
('9BC31A5F-0183-4556-A99B-09E439F74E4A','StudentBirthDate','System.DateTime',0,1),
('67C14F1E-1340-42D5-8EFB-E33C05A8FA11','StudentName','System.String',0,1),

('4F66F2F9-83D8-46E8-BA58-893D8894E900','ParentName','System.String',1,1),
('E7072623-5FEC-4677-847D-E92CE1E9437E','ParentBirthDate','System.DateTime',1,1),

('46DE59AD-DC9B-41E4-9112-8CE88B0E341C','TeacherName','System.String',2,1),
('208E5478-C4A8-472E-B58A-8F53F387BD1A','TeacherBirthDate','System.DateTime',2,1),
('3D955681-ED0B-4404-989F-76D710A5FA50','TeacherEducationPlace','System.String',1,1),
('B7141180-5F4D-49E9-A25F-DC0E6B4844D5','TeacherCareerStartDate','System.DateTime',2,1)

insert into PropertyValues (id,value,PropertyId,EntityId)
values
(newid(),N'������ ���������� ����������',		'67C14F1E-1340-42D5-8EFB-E33C05A8FA11','64CD0FD2-4335-4094-A763-ED0CB40222C3'),--StudentName 1
(newid(),'2003-11-17',							'9BC31A5F-0183-4556-A99B-09E439F74E4A','64CD0FD2-4335-4094-A763-ED0CB40222C3'),--StudentBirthDate 1

(newid(),N'������ ���������� ����������',		'67C14F1E-1340-42D5-8EFB-E33C05A8FA11', '1810BDDC-2D6D-4FF0-8DA4-7FDBA7B5E5AC'),--StudentName 2
(newid(),'2007-11-23',							'9BC31A5F-0183-4556-A99B-09E439F74E4A', '1810BDDC-2D6D-4FF0-8DA4-7FDBA7B5E5AC'),--StudentBirthDate 2

(newid(),N'������� ������������� ����������',	'4F66F2F9-83D8-46E8-BA58-893D8894E900','494FEC84-4034-4402-817C-A67F1C484528'),--ParentName 1
(newid(),'1971-02-27',							'E7072623-5FEC-4677-847D-E92CE1E9437E','494FEC84-4034-4402-817C-A67F1C484528'),--ParentBirthDate 1
(newid(),N'����� �������� ����������',			'4F66F2F9-83D8-46E8-BA58-893D8894E900','72D7E193-9781-4E42-8858-C1AE94456190'),--ParentName 2
(newid(),'1974-02-23',							'E7072623-5FEC-4677-847D-E92CE1E9437E','72D7E193-9781-4E42-8858-C1AE94456190'),--ParentBirthDate 2

(newid(),N'����� ��������� �������������',		'67C14F1E-1340-42D5-8EFB-E33C05A8FA11','{13721765-B6B8-4D37-8A2E-8D390DBBCD16}'),--StudentName 3
(newid(),'2003-11-17',							'9BC31A5F-0183-4556-A99B-09E439F74E4A','{13721765-B6B8-4D37-8A2E-8D390DBBCD16}'),--StudentBirthDate 3

(newid(),N'������ ��������� �������������',		'67C14F1E-1340-42D5-8EFB-E33C05A8FA11', '{BE9AEF15-A5F0-42D6-8A71-FAE913E87986}'),--StudentName 4
(newid(),'2007-11-23',							'9BC31A5F-0183-4556-A99B-09E439F74E4A', '{BE9AEF15-A5F0-42D6-8A71-FAE913E87986}'),--StudentBirthDate 4

(newid(),N'����� ��������� �������������',	'4F66F2F9-83D8-46E8-BA58-893D8894E900','{61F2A74E-E889-4142-9627-5340F1195196}'),--ParentName 3
(newid(),'1971-02-27',							'E7072623-5FEC-4677-847D-E92CE1E9437E','{61F2A74E-E889-4142-9627-5340F1195196}'),--ParentBirthDate 3
(newid(),N'��������� ���������� �������������',			'4F66F2F9-83D8-46E8-BA58-893D8894E900','FF93CC19-6DC5-491F-96B2-6A6305A85241'),--ParentName 4
(newid(),'1974-02-23',							'E7072623-5FEC-4677-847D-E92CE1E9437E','FF93CC19-6DC5-491F-96B2-6A6305A85241'),--ParentBirthDate 4

(newid(),N'������ ����������� ����������',		'46DE59AD-DC9B-41E4-9112-8CE88B0E341C','B3FBA83F-C854-4486-B12F-C913307DBC72'),--TeacherName
(newid(),'1988-11-23',							'208E5478-C4A8-472E-B58A-8F53F387BD1A','B3FBA83F-C854-4486-B12F-C913307DBC72'),--TeacherBirthDate
(newid(),N'������� ��������������� �����������',	'3D955681-ED0B-4404-989F-76D710A5FA50','B3FBA83F-C854-4486-B12F-C913307DBC72'),--TeacherEducationPlace
(newid(),'2009-10-10',							'B7141180-5F4D-49E9-A25F-DC0E6B4844D5','B3FBA83F-C854-4486-B12F-C913307DBC72')--TeacherCareerStartDate

insert into ChildParents (id,ChildId,ParentId)
values
(newid(),'64CD0FD2-4335-4094-A763-ED0CB40222C3', '494FEC84-4034-4402-817C-A67F1C484528'),
(newid(),'64CD0FD2-4335-4094-A763-ED0CB40222C3', '72D7E193-9781-4E42-8858-C1AE94456190'),
(newid(),'1810BDDC-2D6D-4FF0-8DA4-7FDBA7B5E5AC', '494FEC84-4034-4402-817C-A67F1C484528'),
(newid(),'1810BDDC-2D6D-4FF0-8DA4-7FDBA7B5E5AC', '72D7E193-9781-4E42-8858-C1AE94456190'),
(newid(),'{13721765-B6B8-4D37-8A2E-8D390DBBCD16}','{61F2A74E-E889-4142-9627-5340F1195196}'),
(newid(),'{BE9AEF15-A5F0-42D6-8A71-FAE913E87986}','{61F2A74E-E889-4142-9627-5340F1195196}'),
(newid(),'{13721765-B6B8-4D37-8A2E-8D390DBBCD16}','FF93CC19-6DC5-491F-96B2-6A6305A85241'),
(newid(),'{BE9AEF15-A5F0-42D6-8A71-FAE913E87986}','FF93CC19-6DC5-491F-96B2-6A6305A85241')

insert into Subjects(id, name)
values ('{BF0B2F87-F238-482E-856C-1CC1FBDC5CAF}',N'������� ����'),
('{37F31B7B-424C-4CC6-9779-92EE37EEC065}',N'����������'),
('{DBB13052-3F31-4FB3-84E6-038D71456150}',N'����������'),
('{90F76C60-2901-496F-AC13-B56B8B9D746A}',N'������'),
('{D9F674DF-B9DE-46EB-B6F6-EDC86841AAD5}',N'�������������� ����������'),
('{775C76AF-E646-48F8-A8C7-8E1FC9C530B7}',N'�����'),
('{D0A02F60-4B4B-4BB7-B0F9-40ECCCEBCF66}',N'����������� ����'),
('{E8C76081-F237-4822-ADCF-69CEF86389A7}',N'���������� ��������'),
('{1B5A1809-22EB-48B5-9047-10098F10E415}',N'��������'),
('{C1247876-62DF-4EFF-A855-6D742A3877E2}',N'����������'),
('{77F40791-B21F-4581-8040-DF34E425C86A}',N'��������������'),
('{9DB4146A-62C0-40F0-9CF5-0096E882333C}',N'�������')


insert into Classes (id, Number, Letter)
values  ('{DE18211F-6A1D-40D3-987F-0814C4A67B2E}',7,N'�'),
		('{1A6B1BF8-0BB7-45F8-93F8-63A98BD8B260}',9,N'�')

insert into ClassStudents (id, ClassId, StudentId)
values  (newid(),'{DE18211F-6A1D-40D3-987F-0814C4A67B2E}','64CD0FD2-4335-4094-A763-ED0CB40222C3'),
		(newid(),'{DE18211F-6A1D-40D3-987F-0814C4A67B2E}','{BE9AEF15-A5F0-42D6-8A71-FAE913E87986}'),
		(newid(), '{1A6B1BF8-0BB7-45F8-93F8-63A98BD8B260}','1810BDDC-2D6D-4FF0-8DA4-7FDBA7B5E5AC'),
		(newid(), '{1A6B1BF8-0BB7-45F8-93F8-63A98BD8B260}','13721765-B6B8-4D37-8A2E-8D390DBBCD16')

insert into [Messages] (id,[from],[to],[date],messagebody)
  values (newid(),'parent1','teacher1','2020-11-14',N'������')

