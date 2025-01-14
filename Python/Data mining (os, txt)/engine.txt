__version__= "1.0.0"

import os
import re
import model
import datetime as dt
from tkinter import filedialog

def populate_expressions():
    expressions =   [r"(\d{2}\s){2}\d{6}", \
                    r"HU\s\d{4}\s[A-Za-záéóöőúüű]+\,\s.+", \
                    r"[A-GI-Z][A-TV-Z]\s\d{1,}\s[A-Za-zäß']+\,\s.+", \
                    r"\d{4}\'\d{2}\s[\D\s]+", \
                    r"HU[A-Z]{5}\.(\d{2}\-){2}\d{6}", \
                    r"\d{8}(-\d{8}){2}", \
                    r"[\w\.-]+@[\w\.-]+[a-z]{2,4}", \
                    r"\d{8}#cegkapu", \
                    r"[13]\d{6}\s\d{4}", \
                    r"[24]\d{6}\s\d{4}", \
                    r"\d+\s(\d{3}\s){2}[A-Z]{3}", \
                    r"\d{4}(\D*\d{2}){2}"]
    return expressions
        
def get_match(pattern:str, line:str):
    expression = re.compile(pattern)
    match = expression.search(line)
    '''
    part = line.split(';')[1]
    match = expression.match(part)
    '''
    if not match is None:
        return match.group(0)
    
def populate_matches(expressions:list[str], line:str, matches:list[str]):
    length = len(expressions)
    for i in range(0, length):
        match = get_match(expressions[i], line)  
        
        if match is not None:
            matches[i] = match
    
def get_matches_readlines(path:str):
    expressions = populate_expressions()
    matches=[None]*12
    
    with open(path, 'r', -1, 'utf-8', 'ignore') as file:
        for line in file.readlines():
            populate_matches(expressions, line, matches)      
    return matches

def print_lines(path:str): 
    with open(path, 'r', -1, 'utf-8', 'ignore') as file:
        for line in file.readlines():
            print(line)

def get_matches_read(path:str):
    expressions = populate_expressions()
    matches=[None]*12
    
    with open(path, 'r', -1, 'utf-8', 'ignore') as file:
        content = file.read()  
        
    populate_matches(expressions, content, matches)   
    return matches

def get_instance(matches:list[str]):
    return model.Company(matches[0], matches[1], matches[2], matches[3], matches[4], matches[5], matches[6], matches[7], matches[8], matches[9], matches[10],
                dt.datetime.strptime(matches[11], '%Y.%m.%d'))

def process(dir:str, companies=[]):
    for file in os.listdir(dir):
        path = dir + '\\' + file
        if os.path.isfile(path):
            companies.append(get_instance(get_matches_readlines(path)))
                    
    for i in companies:
        print(i.id, i.office, i.foreign_office, i.scope, i.eu_registration, i.bank_account, i.address, i.email_contact, i.male_personal, i.female_personal, i.capital, i.time, sep=',')

def get_path():
    dir = os.path.dirname(__file__)
    path = filedialog.askdirectory( title = 'Directory', initialdir = dir, mustexist=False)    
    if len(path) > 0:
        return path