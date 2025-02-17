__version__= "1.0.0"

import os
import re
import shutil
import datetime

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

def organise_files_extension_os(root:str, dir:str, file_extensions:dict):  
    for key in file_extensions.keys():    
        path = os.path.join(root, file_extensions[key])
               
        if not os.path.exists(path):     
             os.mkdir(path)

        for file in os.listdir(dir):    
            if os.path.isfile(root + '/' + file):
                if file.endswith(key):
                    os.replace(dir + '/' + file, path + '/' + file)
                                
def organise_files_creation_os(root:str, dir:str, file_extensions:dict):  
    for file in os.listdir(dir):
        if os.path.isfile(dir + '/' + file):
            
            year = datetime.datetime.fromtimestamp(os.path.getmtime(dir + '/' + file)).year
            month = datetime.datetime.fromtimestamp(os.path.getmtime(dir + '/' + file)).month
            day = datetime.datetime.fromtimestamp(os.path.getmtime(dir + '/' + file)).day
            
            year = str(year).zfill(4)
            month= str(month).zfill(2)
            day =  str(day).zfill(2)
                   
            path:str = os.path.join(str(root), str(year), str(month), str(day))

            if not os.path.exists(path): 
                os.makedirs(path)   

            for key in file_extensions.keys():
                if file.endswith(key):
                    path:str=os.path.join(path, file_extensions[key])
                    break 

            if not os.path.exists(path): 
                os.makedirs(path)   
                   
            os.replace(dir + '/' + file, path + '/' + file)

def organise_files_date_os(root:str, dir:str, file_extensions:dict):   
    for file in os.listdir(dir):
        if os.path.isfile(dir + '/' + file): 
            if not re.search("^\w+\s\w+\s\d{4}(-\d{2}){2}\.[a-z]+$", file):
                continue
            
            year=  re.split(r"\s|-", file)[-3]
            month= re.split(r"\s|-", file)[-2]
            
            month_name = datetime.date(1900, int(month), 1).strftime('%B') 
            path:str = os.path.join(str(root), str(year), str(month_name))

            if not os.path.exists(path): 
                os.makedirs(path)   
                
            for key in file_extensions.keys():
                if file.endswith(key):
                    path:str=os.path.join(path, file_extensions[key])
                    break 

            if not os.path.exists(path): # isdir
                os.makedirs(path)   

            os.replace(dir + '/' + file, path + '/' + file)     
            
def organise_files_title_os(root:str, dir:str, file_extensions:dict):   
    for file in os.listdir(dir):
        if os.path.isfile(dir + '/' + file): 
            if not re.search("^\w+\s\w+\s\d{4}(-\d{2}){2}\.[a-z]+$", file):
                continue
            
            title= file.split()[1].capitalize()
            path:str = os.path.join(str(root), str(title))

            if not os.path.exists(path): 
                os.makedirs(path)   
                
            for key in file_extensions.keys():
                if file.endswith(key):
                    path:str=os.path.join(path, file_extensions[key])
                    break 

            if not os.path.exists(path): # isdir
                os.makedirs(path)   

            os.replace(dir + '/' + file, path + '/' + file)   
            
def organise_files_organisation_os(root:str, dir:str, file_extensions:dict):   
    for file in os.listdir(dir):
        if os.path.isfile(dir + '/' + file): 
            if not re.search("^\w+\s\w+\s\d{4}(-\d{2}){2}\.[a-z]+$", file):
                continue
            
            organisation= file.split()[0].capitalize()
            path:str = os.path.join(str(root), str(organisation))

            if not os.path.exists(path): 
                os.makedirs(path)   
                
            for key in file_extensions.keys():
                if file.endswith(key):
                    path:str=os.path.join(path, file_extensions[key])
                    break 

            if not os.path.exists(path): # isdir
                os.makedirs(path)   

            os.replace(dir + '/' + file, path + '/' + file)   

def access_files_recursive_os(root:str, dir:str, file_extensions:dict, organise_files_os:object):        
    organise_files_os(root, dir, file_extensions)  
       
    for file in os.listdir(dir): 
        path = os.path.join(dir, file)      
         
        if os.path.isdir(path):
            access_files_recursive_os(root, path, file_extensions, organise_files_os)   
    return True