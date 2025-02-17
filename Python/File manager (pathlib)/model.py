__version__= "1.0.0"

import os
import re
import shutil
import datetime
from pathlib import Path

os.system('cls')

def populate_file_extensions():
    dictionary:dict={}  
    dictionary['.docx']='Microsoft Word-dokumentum'
    dictionary['.xls']='Microsoft Excel 97-2003-as munkalap'
    dictionary['.xlsm']='Makróbarát Microsoft Excel-munkalap'
    dictionary['.pptx']='Microsoft PowerPoint-bemutató'
    dictionary['.xlsx']='Microsoft Excel-munkalap'
    dictionary['.txt']='Szöveges dokumentum'
    dictionary['.rtf']='Rich Text formátum'
    dictionary['.pdf']='Microsoft Edge PDF Document'
    
    return dictionary

def organise_files_extension_pathlib(root:str, dir:object, file_extensions:dict): 
    for key in file_extensions.keys():
        path:object = Path(root) / file_extensions[key]

        if not Path(path).exists():     
            Path(path).mkdir()
     
        for file in Path(dir).iterdir():
            if file.is_file():
                if file.suffix == key: 
                    file.replace(Path(path) / file.name) 

def organise_files_creation_pathlib(root:str, dir:object, file_extensions:dict):    
    for file in Path(dir).iterdir():
        if file.is_file():

            year =datetime.datetime.fromtimestamp(file.stat().st_mtime).year
            month = datetime.datetime.fromtimestamp(file.stat().st_mtime).month
            day =datetime.datetime.fromtimestamp(file.stat().st_mtime).day
            
            year = str(year).zfill(4)
            month= str(month).zfill(2)
            day =  str(day).zfill(2)

            path:object = Path(root) / str(year) / str(month) / str(day)

            if not Path(path).exists():
                Path(path).mkdir(parents=True)

            for key in file_extensions.keys():
                if file.suffix == key:
                    path:object = Path(path) / file_extensions[key]
                    break 
                
            if not Path(path).exists():
                Path(path).mkdir() 

            file.replace(Path(path) / file.name)              
    return True

def organise_files_date_pathlib(root:str, dir:object, file_extensions:dict):   
    for file in Path(dir).iterdir():
        if file.is_file():
            if not re.search("^\w+\s\w+\s\d{4}(-\d{2}){2}\.[a-z]+$", file.name):
                continue

            year=  re.split(r"\s|-", file.name)[-3]
            month= re.split(r"\s|-", file.name)[-2]
            
            month_name = datetime.date(1900, int(month), 1).strftime('%B') 
            path:object = Path(root) / year / month_name

            if not Path(path).exists():
                Path(path).mkdir(parents=True)

            for key in file_extensions.keys():
                if file.suffix == key:
                    path:object = Path(path) / file_extensions[key]
                    break 
                
            if not Path(path).exists():
                Path(path).mkdir() 

            file.replace(Path(path) / file.name) 
            
def organise_files_title_pathlib(root:str, dir:object, file_extensions:dict):   
    for file in Path(dir).iterdir():
        if file.is_file():
            if not re.search("^\w+\s\w+\s\d{4}(-\d{2}){2}\.[a-z]+$", file.name):
                continue

            title= file.name.split()[1].capitalize()
            path:object = Path(root) / title

            if not Path(path).exists():
                Path(path).mkdir(parents=True)

            for key in file_extensions.keys():
                if file.suffix == key:
                    path:object = Path(path) / file_extensions[key]
                    break 
                
            if not Path(path).exists():
                Path(path).mkdir() 

            file.replace(Path(path) / file.name)       
            
def organise_files_organisation_pathlib(root:str, dir:object, file_extensions:dict):   
    for file in Path(dir).iterdir():
        if file.is_file():
            if not re.search("^\w+\s\w+\s\d{4}(-\d{2}){2}\.[a-z]+$", file.name):
                continue

            organisation= file.name.split()[0].capitalize()
            path:object = Path(root) / organisation

            if not Path(path).exists():
                Path(path).mkdir(parents=True)

            for key in file_extensions.keys():
                if file.suffix == key:
                    path:object = Path(path) / file_extensions[key]
                    break 
                
            if not Path(path).exists():
                Path(path).mkdir() 

            file.replace(Path(path) / file.name)

def access_files_recursive_pathlib(root:str, dir:object, file_extensions:dict, organise_files_pathlib:object):
    organise_files_pathlib(root, dir, file_extensions)                               
    for file in Path(dir).iterdir():
        path:object = Path(dir / file)
        
        if file.is_dir():  
            access_files_recursive_pathlib(root, path, file_extensions, organise_files_pathlib)   
    return True

