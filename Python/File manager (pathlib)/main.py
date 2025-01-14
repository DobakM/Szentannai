__version__= "1.0.0"

import os
import time
import shutil
import model as model

os.system('cls')

def main_menu():
    while True:  
        print('Main:', 'H:  Help', 'M:  Menu', 'Q:  Quit',  sep='\n')   
        print()                         
        while True:              
            option = input('Select option:')  
            option = option.strip().lower()
            print() 
                                                        
            if option in ['h', 'm', 'q']:                                    
                break                         
        if option == 'h':
            help()
        elif option == 'm':
            menu()          
        else:                 
            break
             
def menu():
    while True:
        print('Menu:', 'E:  Extension', 'C:  Creation', 'N:  Name', 'Q:  Quit', sep='\n') 
        print()   
        while True:              
            option = input('Select option:')      
            option = option.strip().lower()
            print() 
                                         
            if option in  ['e', 'c', 'n', 'q']:                
                break      
        if (option == 'e' or option == 'c'):       
            run(option)
        elif option == 'n':
            sub_menu()
        else:                 
            break 
               
def sub_menu():
    while True:
        print('Sub menu:', 'O:  Organisation', 'T:  Title', 'D:  Date', 'Q:  Quit', sep='\n')
        print() 
        while True:              
            option = input('Select option:')    
            option = option.strip().lower()
            print() 
                                 
            if option in  ['o', 't', 'd', 'q']:           
                break   
        if (option == 'o' or option == 't' or option == 'd'):           
            run(option)
        else:                 
            break 
                
def help():    
    menu = "Main Menu\n" + \
            "├── Info\n" + \
            "├── Quit\n" + \
            "└── Menu\n" + \
            "   ├── Quit\n" + \
            "   ├── Extension\n" + \
            "   ├── Creation Time\n" + \
            "   └── File Name\n" + \
            "       ├── Organisation\n" + \
            "       ├── Date\n" + \
            "       ├── Title\n" + \
            "       └── Quit"              
    print(menu)
    
def routines(option):
    match option:
        case 'e':
            return model.organise_files_extension_pathlib 
        case 'c':
            return model.organise_files_creation_pathlib 
        case 'o':
            return model.organise_files_organisation_pathlib 
        case 't':
            return model.organise_files_title_pathlib 
        case 'd':
            return model.organise_files_date_pathlib 
        case default:
            return None    

def reset():
    dir = os.path.dirname(__file__)
    
    shutil.rmtree(dir + '\\' + 'Files (copy)', ignore_errors=True)
    shutil.copytree(dir + '\\' + 'Files (original)', dir + '\\' + 'Files (copy)', dirs_exist_ok=True )
    '''
    Not to delete:
    os.removedirs(dir + '\\' + 'Files (source)')
    '''

def run(option:str):
    reset()
    
    routine = routines(option)
    dir = os.path.dirname(__file__) 
    file_extensions = model.populate_file_extensions()
    
    if model.access_files_recursive_pathlib(dir +  '\\' + 'Files (copy)', dir +  '\\' + 'Files (copy)', file_extensions, routine):
        print('done')      

if __name__ == '__main__':
    main_menu()   
        
