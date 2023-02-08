import pandas as pd
import numpy as np
import tensorflow as tf
import sklearn.preprocessing as sp


csv_path = "tracker_data.csv"
rythm_model_path = "Models/model_r-3class_AHW1130-170509425044.h5"
z_model_path = "Models/model_z_new_AUW1206-123420358629.h5"
y_model_path = "Models/model_AHU1130-163517936046.h5"
forearm_model_path = "Models/model_f_AHU1130-164853660046.h5"

xcolumns = ['Right Hand Tracker Postion.x', 'Right Hand Tracker Postion.y', 'Right Hand Tracker Postion.z', 
            'Right Hand Tracker Rotation.x', 'Right Hand Tracker Rotation.y', 'Right Hand Tracker Rotation.z', 
            'Right Hand Tracker Velocity.x', 'Right Hand Tracker Velocity.y', 'Right Hand Tracker Velocity.z', 
            'Right Hand Tracker AngularVelocity.x', 'Right Hand Tracker AngularVelocity.y', 'Right Hand Tracker AngularVelocity.z'
            ]

df = pd.read_csv(path)

rythm_model = tf.keras.models.load_model(rythm_model_path)
z_model = tf.keras.models.load_model(z_model_path)
y_model = tf.keras.models.load_model(y_model_path)
forearm_model = tf.keras.models.load_model(forearm_model_path)


data_list = []
scaler = sp.RobustScaler()
scaler = scaler.fit(df[xcolumns].values)
df.loc[:, xcolumns] = scaler.transform(df[xcolumns].to_numpy())
temp = df[xcolumns].values.tolist()

for i in range(542-len(df)):
    temp.append([0 for _ in range(len(xcolumns))])
data_list.append(temp)

input_data = np.array(data_list, dtype=float)

rythm_score = rythm_model.predict(input_data).argmax(axis=1)
z_score = z_model.predict(input_data).argmax(axis=1)
y_score = y_model.predict(input_data).argmax(axis=1)
forearm_score = forearm_model.predict(input_data).argmax(axis=1)

import csv
f = open('out.csv', 'w')
data = [rythm_score, z_score, y_score, forearm_score]
writer = csv.writer(f)
writer.writerow(data)
f.close()



