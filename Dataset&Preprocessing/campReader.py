# -*- coding: utf-8 -*-
"""
Created on Sat Nov  9 18:54:08 2019

@author: heziy
"""

import pandas as pd
#chunksize = 10 ** 8
#for chunk in pd.read_csv("flights.csv", chunksize=chunksize):
#    print(chunk)
json_file = 'campsites.json'
df = pd.read_json(json_file)
header=df.columns
'''
header:
Index([
'city', 
'country', 
'county', 
'distance', 
'excerpt',(comments)
'id', 
'latitude',
'longitude', 
'name', 
'rating',
'ratings_average',
'ratings_count',
'ratings_value', 
'region', 
'table_row', 
'type', 
'type_specific', 
'url'
],
dtype='object')
'''
city=df['city']
country=df['country']
county=df['county']
excerpt=df['excerpt']
ratingscount=df['ratings_count']
region=df['region']
name=df['name']
ratingavg=df['ratings_average']
campUrl=df['url']
campType=df['type']
type_specific=df['type_specific']
lat=df['latitude']
lng=df['longitude']
table = df['table_row']
ratingsValue=df['ratings_value']
typ=df['type']
#check country
#count=0
#for i in country:
#      if i!='United States':
#            print(i)
#      if i!='':
#            print(count)
#      count=count+1
USindex=[]
countUS=0
countCanada=0
Canadaindex=[]
countNone=0
NoneIndex=[]
countMexico=0
MexicoIndex=[]
countElse=0
count=0
for i in country:
      if i=='United States':
            USindex.append(count)
            countUS=countUS+1
      elif i=='Canada':
            Canadaindex.append(count)
            countCanada=countCanada+1
      elif i=='Mexico':
            MexicoIndex.append(count)
            countMexico=countMexico+1
      elif i=='':
            NoneIndex.append(count)
            countNone=countNone+1
      else:
            pass#print(i)
      count=count+1
US_lat=[]
US_lng=[]
US_rat=[]
US_excerpt=[]
a=excerpt
for i in USindex:
    US_lat.append(lat[i])
    US_lng.append(lng[i])
    US_rat.append(ratingavg[i])
    #print(excerpt[i])
    #(excerpt[i]).replace('"' ,"")
    excerpt_str=excerpt[i]+"!!!!"
    US_excerpt.append(excerpt_str.replace('"' ,''))
    #print(excerpt[i])
print(a==excerpt)
df = pd.DataFrame({
        'lat':US_lat,
        'lng':US_lng,
        'rat':US_rat
        })
##store whole data
df.to_csv("data.csv",sep=',',index=False,header=False)
df = pd.DataFrame({
        'excerpt':US_excerpt
        })
df.to_csv("excerpt.csv",sep=',',index=False,header=False)
#
#US_lat=[]
#US_lng=[]
#excerpt5=[]
##rat5
#for i in USindex:
#    if ratingavg[i]==5.0:
#        US_lat.append(lat[i])
#        US_lng.append(lng[i])
#        excerpt5.append(excerpt[i])
#    
#df = pd.DataFrame({
#        'lat':US_lat,
#        'lng':US_lng,
#        'excerpt':excerpt5
#        })
#df.to_csv("rat5.csv",sep=',',index=False,header=False)
            
