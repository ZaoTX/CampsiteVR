# -*- coding: utf-8 -*-
"""
Created on Thu Nov 21 14:19:56 2019

@author: ZiyaoHe
"""

import csv
from geojson import Feature, FeatureCollection, Point

features = []
with open('rat5.csv', newline='', encoding="utf8") as csvfile:
    reader = csv.reader(csvfile, delimiter=',')
    count=0
    for latitude, longitude,excerpt in reader:
        latitude=float(latitude)
        longitude=float(longitude)
        if count<10:
            print(latitude, longitude)
            print(type(latitude))
            count=count+1
        latitude, longitude = map(float, (latitude, longitude))
        features.append(
            Feature(
                geometry = Point((longitude, latitude)),
                properties = {
                    'excerpt': excerpt
                }
            )
        )

collection = FeatureCollection(features)
with open("rating5.json", "w") as f:
    f.write('%s' % collection)

features = []
with open('data.csv', newline='', encoding="utf8") as csvfile:
    reader = csv.reader(csvfile, delimiter=',')
    count=0
    for latitude, longitude,rating in reader:
        latitude=float(latitude)
        longitude=float(longitude)
        if count<10:
            print(latitude, longitude)
            print(type(latitude))
            count=count+1
        latitude, longitude = map(float, (latitude, longitude))
        features.append(
            Feature(
                geometry = Point((longitude, latitude)),
                properties = {
                    'rating': float(rating)
                }
            )
        )

collection = FeatureCollection(features)
with open("USCampsites.json", "w") as f:
    f.write('%s' % collection)