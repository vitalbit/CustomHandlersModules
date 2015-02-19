import pytest
from selenium import webdriver
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.support.ui import Select

def set_up():
  driver = webdriver.Firefox()
  driver.get("http://localhost/CustomHandlersModules/")
  return driver

def test_auth():
  driver = set_up()
  enter = driver.find_element_by_id('enter')
  enter.click()
  login = driver.find_element_by_id('login')
  password = driver.find_element_by_id('password')
  login.send_keys('admin')
  password.send_keys('qwerty')
  subm = driver.find_element_by_id('subm_button')
  subm.click()
  logout = WebDriverWait(driver, 120).until(EC.presence_of_element_located((By.ID, 'exit')))
  assert logout.get_attribute("id") == "exit"
  tear_down(driver)
  
def tear_down(driver):
  driver.close()