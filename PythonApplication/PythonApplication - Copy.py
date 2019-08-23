

# -*- coding: utf-8 -*-
"""
Created on Mon Apr 22 20:16:38 2019

@author: Administrator
"""
import numpy as np

import matplotlib.pyplot as plt
import matplotlib.ticker as ticker

plt.rcParams['font.sans-serif']=['SimHei'] #用来正常显示中文标签
plt.rcParams['axes.unicode_minus']=False #用来正常显示负号 

#x = np.linspace(0, 2 * np.pi, 10)
#y1, y2 = np.sin(x), np.cos(x)

names = ['20181025', '20181125', '20181225', '20190125', '20190225', '20190325']
x = range(len(names))

#塔顶累计位移
y1 = [0.0,-0.1,0.9,2.2,2.2,2.2]
y2=[0.0,-0.1,0.9,0.9,0.8,0.9]
y3=[0.0,0.1,-1.0,-2.0,-1.9,-1.9]
y4=[0.0,-0.1,-1.3,-1.3,-1.2,-1.3]


#1#塔
y1 = [0.0,-1.2,4.3,10.2,11.1,11.7]
y2=[0.0,3.3,-2.1,-8.4,-9.0,-9.8]
y3=[0.0,-0.4,6.2,7.0,7.1,7.3]
y4=[0.0,1.2,-7.3,-7.8,-8.0,-8.1]

#2#塔
#0.0	1.1	-1.3	-3.9	-3.8	-3.8
#0.0	-1.7	2.5	5.0	5.0	4.9
#0.0	-0.2	-2.5	-2.6	-2.8	-2.8
#0.0	0.1	3.3	3.2	3.2	3.3

y1=[0.0,1.1,-1.3,-3.9,-3.8,-3.8]
y2=[0.0,-1.2,2.5,5.0,5.0,4.9]
y3=[0.0,-0.2,-2.5,-2.6,-2.8,-2.8]
y4=[0.0,0.1,3.3,3.2,3.2,3.3]

plt.xticks(x, names)
plt.plot(x, y1, marker='o',  mfc='w',label=u'TS21')

plt.plot(x, y2, marker='x', ms=10, mfc='w',label=u'TS22')

plt.plot(x, y3, marker='+', ms=10, mfc='w',label=u'TS23')
plt.plot(x, y4, marker='*', ms=10, mfc='w',label=u'TS24')

plt.gca().yaxis.set_major_formatter(ticker.FormatStrFormatter('%1.1f'))  
plt.legend()  # 让图例生效
plt.show()
