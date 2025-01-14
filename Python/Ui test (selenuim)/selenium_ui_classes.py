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
    
class WebDriverBuilder():           
    def __init__(self):
        self.driver = None
                         
    def initialize(self, link:str):
        service = Service(r"AppData\Local\Packages\chromedriver-win64\chromedriver.exe")
        self.driver = webdriver.Chrome(service = service)
        self.driver.get(link)     
      
class UITestRunner():
    def __init__(self, suite:list[UITest], driver:webdriver.Chrome):
        self.methodes = self.populate_methodes()   
        self.driver = driver
        self.suite = suite
        self.value = None
      
    def enter_input(self, parameters:list[UIParameters]):
        element = self.driver.find_element(parameters[0].by, parameters[0].path)
        element.send_keys(parameters[0].value)
        element.submit()
    
    def enter_multi_input(self, parameters:list[UIParameters]):
        element = self.driver.find_element(parameters[0].by, parameters[0].path)
        element.send_keys(parameters[0].value)
        element.send_keys(Keys.ENTER)  
     
    def click_element(self, parameters:list[UIParameters]):
        element = self.driver.find_element(parameters[0].by, parameters[0].path)
        element.click()  
        
    def select_date(self, parameters:list[UIParameters]):
        element = self.driver.find_element(parameters[0].by, parameters[0].path)
        element.click()  
        element.send_keys(Keys.CONTROL, 'a') 
        element.send_keys(parameters[0].value)  
               
    def select_drop_down(self, parameters:list[UIParameters]):
        element = WebDriverWait(self.driver,6).until(EC.presence_of_element_located([parameters[0].by, parameters[0].path]))
        element.click()
        
        element = WebDriverWait(self.driver,6).until(EC.presence_of_element_located([parameters[1].by, parameters[1].path]))
        html = element.get_attribute('innerHTML')
        print(html)
        
        element = WebDriverWait(self.driver,6).until(EC.presence_of_element_located([parameters[2].by, parameters[2].path]))
        element.click()
        
    def confirmation(self,parameters:list[UIParameters]):
        time.sleep(3.5)   
        try:
            self.value =  WebDriverWait(self.driver,30).until(EC.presence_of_element_located([parameters[0].by, parameters[0].path])).__getattribute__("text")
        finally:       
            self.driver.close()        

    def populate_methodes(cls):
        return\
        { 
            0:cls.enter_input,
            1:cls.enter_multi_input,
            2:cls.click_element,
            3:cls.select_date,
            4:cls.select_drop_down,
            5:cls.confirmation
        }     

    def run(self):
        time.sleep(5.5) 
        for i in self.suite:
            time.sleep(2.5) 
            self.methodes[i.key](i.parameters)
                     
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
    
builder = WebDriverBuilder()
builder.initialize("https://demoqa.com/automation-practice-form")

runner = UITestRunner(suite, builder.driver  )        
runner.run()

print(runner.value)

'''
hints:

https://stackoverflow.com/questions/72188813/how-can-i-call-another-method-of-the-same-class-without-an-instance

'''