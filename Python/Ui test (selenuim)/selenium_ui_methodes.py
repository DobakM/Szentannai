from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.support.wait import WebDriverWait
from selenium.webdriver.chrome.service import Service
from selenium.webdriver.chrome.options import Options
from selenium.webdriver.support.select import Select as WebDriverSelect
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.common.by import By
from dataclasses import dataclass
from selenium import webdriver
from typing import Callable, NewType
import pytest
import time
import os

dir = os.path.dirname(__file__)

@dataclass(frozen = True)    
class UIParameters:
    by:By 
    path:str
    value:str
    
@dataclass(frozen = True)    
class UITest:
    key:int
    parameters:list[UIParameters]
         
suite:list[UITest] =\
[
    UITest(4, [UIParameters(By.XPATH,'//*[@id="state"]/div/div[1]/div[1]', None), UIParameters(By.XPATH,'//*[@id="state"]', None), UIParameters(By.ID,'react-select-3-option-0', None)]),
    UITest(4, [UIParameters(By.XPATH,'//*[@id="city"]/div/div[1]/div[1]', None), UIParameters(By.XPATH,'//*[@id="city"]', None), UIParameters(By.ID,'react-select-4-option-0', None)]),
    UITest(0, [UIParameters(By.XPATH, '//*[@id="currentAddress"]','1600 Pennsylvania Avenue NW, Washington, DC 20500')]),
    UITest(0, [UIParameters(By.CSS_SELECTOR, 'input[type="file"]', dir + '\Mark Zuckerberg.jpg')]),
    UITest(2, [UIParameters(By.XPATH,'//*[@id="genterWrapper"]/div[2]/div[1]/label', None)]),
    UITest(2, [UIParameters(By.XPATH,'//*[@id="hobbiesWrapper"]/div[2]/div[1]/label', None)]),
    UITest(2, [UIParameters(By.XPATH,'//*[@id="hobbiesWrapper"]/div[2]/div[2]/label', None)]),
    UITest(2, [UIParameters(By.XPATH,'//*[@id="hobbiesWrapper"]/div[2]/div[3]/label',None)]), 
    UITest(3, [UIParameters(By.XPATH,'//*[@id="dateOfBirthInput"]', '10 Mar 1999')]), 
    UITest(0, [UIParameters(By.XPATH,'//*[@id="userEmail"]', 'joe@freemail.hu')]), 
    UITest(0, [UIParameters(By.XPATH,'//*[@id="userNumber"]','0123456789')]),
    UITest(1, [UIParameters(By.XPATH,'//*[@id="subjectsInput"]', 'Biology')]),
    UITest(1, [UIParameters(By.XPATH,'//*[@id="subjectsInput"]', 'Maths')]),
    UITest(0, [UIParameters(By.XPATH,'//*[@id="firstName"]','Joe')]),
    UITest(0, [UIParameters(By.XPATH,'//*[@id="lastName"]','Smith')]),
    UITest(5, [UIParameters(By.ID, 'example-modal-sizes-title-lg', None)])
]

def initialize_driver(link:str):
    service = Service(r"AppData\Local\Packages\chromedriver-win64\chromedriver.exe")
    driver = webdriver.Chrome(service = service)
    driver.get(link) 
    return driver

def enter_input(parameters:list[UIParameters]):
    element = driver.find_element(parameters[0].by, parameters[0].path)
    element.send_keys(parameters[0].value)
    element.submit()

def enter_multi_input(parameters:list[UIParameters]):
    element = driver.find_element(parameters[0].by, parameters[0].path)
    element.send_keys(parameters[0].value)
    element.send_keys(Keys.ENTER)  
    
def click_element( parameters:list[UIParameters]):
    element = driver.find_element(parameters[0].by, parameters[0].path)
    element.click()  
    
def select_date( parameters:list[UIParameters]):
    element = driver.find_element(parameters[0].by, parameters[0].path)
    element.click()  
    element.send_keys(Keys.CONTROL, 'a') 
    element.send_keys(parameters[0].value)  
            
def select_drop_down(parameters:list[UIParameters]):
    element = WebDriverWait(driver, 6).until(EC.presence_of_element_located([parameters[0].by, parameters[0].path]))
    element.click()
    
    element = WebDriverWait(driver, 6).until(EC.presence_of_element_located([parameters[1].by, parameters[1].path]))
    html = element.get_attribute('innerHTML')
    print(html)
    
    element = WebDriverWait(driver, 6).until(EC.presence_of_element_located([parameters[2].by, parameters[2].path]))
    element.click()
    
def confirmation(parameter:list[UIParameters]):
    try:
        caption =  WebDriverWait(driver,30).until(EC.presence_of_element_located([parameter[0].by, parameter[0].path])).__getattribute__("text")
        print(caption)
    finally:       
        driver.close()       
        
def run(): 
    time.sleep(5.5)              
    for i in suite:
        methodes[i.key](i.parameters)
        time.sleep(1.5)            
  
def populate_methodes():
    return\
    { 
        0:enter_input,
        1:enter_multi_input,
        2:click_element,
        3:select_date,
        4:select_drop_down,
        5:confirmation
    }  
    
driver:webdriver.Chrome = initialize_driver("https://demoqa.com/automation-practice-form")
methodes = populate_methodes()
run()

'''
hints:

https://www.lambdatest.com/blog/handling-dropdown-in-selenium-webdriver-python/
https://fs2.formsite.com/meherpavan/form2/index.html?1537702596407'
https://elementalselenium.com/tips/5-select-from-a-dropdown
'''

'''
web scraping:
'''

'''
web driver select:

element = driver.find_element(By.XPATH, '//*[@id="state"]')
cb = WebDriverSelect(element)
cb.select_by_index(1)
'''
