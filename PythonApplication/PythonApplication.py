

# -*- coding: utf-8 -*-
"""
Created on Mon Apr 22 20:16:38 2019

@author: Administrator
"""
import numpy as np

import matplotlib.pyplot as plt
import matplotlib.ticker as ticker

from brokenaxes import brokenaxes

#定义函数来显示柱状上的数值
def autolabel(rects,y_data):
    i=0
    factor=1
    space=-0.20
    for rect in rects:
        if 100>y_data[i]>=0:
            space=-0.05
            if(len(rects.patches)<=6):    #个数
                factor=2
            elif (len(rects.patches)<=8):
                factor=4
            else:
                factor=5
        elif 1000>y_data[i]>=100:
            space=-0.08
            if(len(rects.patches)<=6):
                factor=1
            elif (len(rects.patches)<=8):
                factor=2
            else:
                factor=2.8
        elif 10000>y_data[i]>=1000:
            space=-0.10
            if(len(rects.patches)<=6):
                factor=1
            elif (len(rects.patches)<=8):
                factor=2
            else:
                factor=2.8
        elif 100000>y_data[i]>=10000:
            space=-0.14
            if(len(rects.patches)<=6):
                factor=1
            elif (len(rects.patches)<=8):
                factor=2
            else:
                factor=2.8
        elif 1000000>y_data[i]>=100000:
            space=-0.16
            if(len(rects.patches)<=6):    #个数
                factor=1
            elif (len(rects.patches)<=8):
                factor=2
            else:
                factor=2.8
        else:
            space=-0.18
            if(len(rects.patches)<=6):    #个数
                factor=1
            elif (len(rects.patches)<=8):
                factor=2
            else:
                factor=2.8
        height = rect.get_height()
        plt.text(rect.get_x()+rect.get_width()/2.+space*factor, 1.03*height, '%s' % height,fontsize=15)
        i=i+1

itemChosen=5   #0~5

#车重
#车道
#车速
#周一至周日
#不同小时车辆总数
#不同小时平均车速

fontSize=15
#plt.rcParams['figure.figsize'] = (8.0, 6.0)
plt.rcParams['font.sans-serif']=['SimHei'] #用来正常显示中文标签
plt.rcParams['axes.unicode_minus']=False #用来正常显示负号 
plt.xticks(fontsize=fontSize)
plt.yticks(fontsize=fontSize)

totalDays=7    #总天数

#车重
#车道
#车速
#周一至周日
#不同小时车辆总数
#不同小时平均车速
#不同时间>40t车辆数
y_dataList=[
[2466937,17305,1970,376],
[555882,727510,655385,547811],
[368992,915356,1177546,24694],
[384021,323205,318810,320923,336629,406316,396684],
[76436,41453,36264,168533,283727,289617,279444,311993,311057,274101,248725,165238],
[58.1,59.6,59.0,49.8,42.3,42.6,47.8,41.8,40.0,43.4,48.7,53.3],
[5,6,6,0,1,1,1,5,3,2,6,11]
]

## 包含每个柱子对应值的序列
#y_data = [2464623,38589,3826,444]    #车重
#y_data = [572247,715894,662534,556807]    #车道
#y_data = [328598,1487069,657741,34074]    #车速
#y_data = [84873,72122,73096,78501,81604,81276,82651]    #周一至周日

##y_data = [int(77929/totalDays),int(97206/totalDays),int(89124/totalDays),int(75482/totalDays)]    #不同车道日均车辆数
#y_data = [69911,38924,35443,188478,292562,296935,264533,309169,320518,282046,244703,164260]    #不同小时车辆总数
#y_data = [58.6,60.8,59.6,47.2,36.5,40.9,47.0,41.4,38.0,36.0,43.5,50.6]    #不同小时平均车速

y_data = y_dataList[itemChosen]    #不同小时平均车速

x_data = range(1,len(y_data)+1)
multiples = [x/sum(y_data) for x in y_data]

#车重
#车道
#车速
#周一至周日
#不同小时车辆总数
#不同小时平均车速
xticksPrefixList=[
['0～10t','10～20t','20～30t','30t以上'],
['车道1','车道2','车道3','车道4'],
['0～30km/h','30～50km/h','50～70km/h','70km/h以上'],
['周一','周二','周三','周四','周五','周六','周日'],
['0～2','2～4','4～6','6～8','8～10','10～12','12～14','14～16','16～18','18～20','20～22','22～24'],
['0～2','2～4','4～6','6～8','8～10','10～12','12～14','14～16','16～18','18～20','20～22','22～24'],
['0～2','2～4','4～6','6～8','8～10','10～12','12～14','14～16','16～18','18～20','20～22','22～24']
]

xticksPrefix=xticksPrefixList[itemChosen]

#xticksPrefix=['0～10t','10～20t','20～30t','30t以上']    #车重
#xticksPrefix=['车道1','车道2','车道3','车道4']    #车道
#xticksPrefix=['0～30km/h','30～50km/h','50～70km/h','70km/h以上']    #车速
#xticksPrefix=['周一','周二','周三','周四','周五','周六','周日']    #周一至周日
#xticksPrefix=['0～2','2～4','4～6','6～8','8～10','10～12','12～14','14～16','16～18','18～20','20～22','22～24']    #小时

# 柱子总数
N =len(y_data)
# 包含每个柱子下标的序列
index = np.arange(N)

#bax = brokenaxes(ylims=((0, 20000), (80000, 100000)))

bax=plt

# 柱子的宽度
width = 0.5

# 绘图
p2=bax.bar(x_data,y_data, label='动态称重', color='steelblue',width=width,alpha=0.8)

autolabel(p2,y_data)

# 在柱状图上显示具体数值, ha参数控制水平对齐方式, va控制垂直对齐方式
#for x, y in enumerate(y_data):
#    bax.text(x, y + 100, '%s' % y, ha='center', va='bottom')
# 设置标题
#plt.title("Java与Android图书对比")

# 为两条坐标轴设置名称
#plt.xlabel("年份")

ylabelList=[]
ylabelList.append('数量')
ylabelList.append('数量')
ylabelList.append('数量')
ylabelList.append('数量')
ylabelList.append('数量')
ylabelList.append('车速（km/h）')

plt.ylabel("车速（km/h）",fontsize=15)
plt.ylabel("数量",fontsize=15)

plt.ylabel(ylabelList[itemChosen],fontsize=15)

# 添加纵横轴的刻度
#xticksLabel=['%s'%(xticksPrefix[0])+'\n(%.2f%%'%(100*multiples[0])+')']
#for i in range(len(xticksPrefix)):
#    plt.xticks(x_data, ['%s'%(xticksPrefix[0])+'\n(%.2f%%'%(100*multiples[0])+')', '%s'%(xticksPrefix[1])+'\n(%.2f%%'%(100*multiples[1])+')', '%s'%(xticksPrefix[2])+'\n(%.2f%%'%(100*multiples[2])+')', '%s'%(xticksPrefix[3])+'\n(%.2f%%'%(100*multiples[3])+')'])

# 添加纵横轴的刻度(不含比例)
#xticksLabel=['%s'%(xticksPrefix[0])]
#for i in range(len(xticksPrefix)):
#    plt.xticks(x_data, ['%s'%(xticksPrefix[0]), '%s'%(xticksPrefix[1]), '%s'%(xticksPrefix[2]), '%s'%(xticksPrefix[3])])

xticksLabelList=[]

xticksLabel1=['%s'%(xticksPrefix[0])+'\n(%.2f%%'%(100*multiples[0])+')']
for i in range(1,len(xticksPrefix)):
    xticksLabel1=xticksLabel1+['%s'%(xticksPrefix[i])+'\n(%.2f%%'%(100*multiples[i])+')']

xticksLabel2=['%s'%(xticksPrefix[0])]
for i in range(1,len(xticksPrefix)):
    xticksLabel2=xticksLabel2+['%s'%(xticksPrefix[i])]

xticksLabelList.append(xticksLabel1)
xticksLabelList.append(xticksLabel1)
xticksLabelList.append(xticksLabel1)
xticksLabelList.append(xticksLabel2)
xticksLabelList.append(xticksLabel2)
xticksLabelList.append(xticksLabel2)
xticksLabelList.append(xticksLabel2)

xticksLabel=xticksLabelList[itemChosen]

plt.xticks(x_data, xticksLabel)


#plt.xticks([])
ax = plt.gca()
ax.spines['top'].set_visible(False)
ax.spines['right'].set_visible(False)
#ax.spines['bottom'].set_visible(False)
#ax.spines['left'].set_visible(False)

# 显示图例
#plt.legend()
#plt.savefig('tmp.pdf', bbox_inches='tight')
plt.show()

