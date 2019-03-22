DBCC CHECKIDENT (filelist, RESEED, 0)


select * from ManagerList
select * from File_SectionList
select * from FileList
select * from SectionList
select * from File_SliderOrderList
select * from test
delete from File_SectionList
delete from FileList
delete from FileCaptionList
delete from File_SliderOrderList

update FileList set RecordState = 0 From FileList Inner Join File_SectionList on FileList.FileListID = File_SectionList.FileListID Where File_SectionList.SectionListID = 3;

SELECT FileList.FileName FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID WHERE File_SectionList.SectionListID = 3 AND FileList.RecordState = 1

SELECT FileList.* FROM FileList INNER JOIN File_SectionList ON FileList.FileListID = File_SectionList.FileListID WHERE FileList.RecordState = 1 And File_SectionList.SectionListID = 2

--insert into test (sdsd) values (0)
Select SectionListID From SectionList Where SectionName = 'Home_Section1'

SELECT        FileList.*
FROM            File_SectionList INNER JOIN
                         FileList ON File_SectionList.FileListID = FileList.FileListID
WHERE        (File_SectionList.SectionListID = 2) AND (FileList.RecordState = 1)



SELECT        FileList.*, FileCaptionList.Caption
FROM            FileCaptionList INNER JOIN
                         FileList ON FileCaptionList.FileListID = FileList.FileListID
WHERE        (FileList.RecordState = 1)

SELECT FileList.FileListID, FileList.FileName, FileList.RecordState, FileCaptionList.Caption FROM FileList INNER JOIN File_SliderOrderList ON FileList.FileListID = File_SliderOrderList.FileListID INNER JOIN FileCaptionList ON FileList.FileListID = FileCaptionList.FileListID WHERE FileList.RecordState = 1 ORDER BY File_SliderOrderList.SliderOrder



SELECT        count(*)
FROM            File_SliderOrderList INNER JOIN
                         FileList ON File_SliderOrderList.FileListID = FileList.FileListID
WHERE        (FileList.RecordState = 1)

SELECT        FileList.FileListID, FileList.FileName, FileList.RecordState
FROM            FileList INNER JOIN
                         File_SliderOrderList ON FileList.FileListID = File_SliderOrderList.FileListID
WHERE        (FileList.RecordState = 1)
ORDER BY File_SliderOrderList.SliderOrder

select * from File_SectionList
select count(*) from FileList where FileName = 'home_slider1.jpg'

Select count(*) From FileList Where FileName = '';
--Select SectionListID From SectionList Where SectionName = 'Home_Slider'
--insert into ManagerList (UserName, Password) values('rueston', 'Skyjade2019')

--select count(1) from ManagerList where UserName='ruesto' and Password='Skyjade2019'

--insert into SectionList values('Story_Section6')
--select * from test
--Insert Into test (testdc) Values('2') Select SCOPE_IDENTITY()