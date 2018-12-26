### Необходимо рассчитать среднюю стоимость показа рекламы по городам России.
#<user_id>,<country>,<city>,<campaign_id>,<creative_id>,<payment></p>
#11111,RU,Moscow,2,4,0.3
#22222,RU,Voronezh,2,3,0.2
#13413,UA,Kiev,4,11,0.7
from functools import reduce
csv = '''11111,RU,Moscow,2,4,0.3
22222,RU,Voronezh,2,3,0.2
22222,RU,SPb,1,2,0.2
13413,UA,Kiev,4,11,0.7'''
# Start
OPEN_CSV_RU = [line.split(',') for line in csv.split('\n') if 'RU' in line]
averange = str(sum([float(line[5]) for line in OPEN_CSV_RU])/len(OPEN_CSV_RU))
print(f'Средняя стоимость показа рекламы по России: {averange} рублей')