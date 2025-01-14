__version__= "1.0.0"

import os
import time
import model
import shutil

os.system('cls')

def main_menu():
    while True:  
        print('Main:', 'H:  Help', 'M:  Menu', 'Q:  Quit',  sep='\n')    
        print()                         
        while True:              
            option = input('Select option:')  
            option = option.strip().lower()
            print()
                                                        
            if option not in ['h', 'm', 'q']:                                    
                continue
            else:
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
                                         
            if option not in  ['e', 'c', 'n', 'q']:                
                continue
            else:
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
            
            if option not in  ['o', 't', 'd', 'q']:           
                continue
            else:
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
    print()
       
def populate_routines():
    dictionary:dict={}  
    dictionary['e'] = model.organise_files_extension_os 
    dictionary['c'] = model.organise_files_creation_os
    dictionary['o'] = model.organise_files_organisation_os
    dictionary['t'] = model.organise_files_title_os
    dictionary['d'] = model.organise_files_date_os    
    
    return dictionary

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
        
    dir = os.path.dirname(__file__)
    routines = populate_routines()
    routine:object = routines.get(option)   
    file_extensions = model.populate_file_extensions()    

    if model.access_files_recursive_os(dir + '\\' + 'Files (copy)', dir + '\\' + 'Files (copy)', file_extensions, routine):
        print('done')        

if __name__ == '__main__':
    main_menu()    