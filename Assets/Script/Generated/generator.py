'''
Written in python3.6.2

BEGIN_PARAMS
'''

FILES = ["TrophySheet", "EncounterObjective","EncounterSheet"]

PATH_OUTPUT = "output/{}.cs"

EXT_DATA = "{}.csv"
EXT_ITEM = "{}_item.txt"
EXT_SCRIPT = "{}_script.txt"

'''
END_PARAMS
'''

import csv

def parseList(named_dict):
    for key in named_dict:
        if key.startswith("lst_"):
            named_dict[key] = '\n"' + '",\n"'.join([i.strip() for i in named_dict[key].split(",")]) + '"\n'
            if len(named_dict[key]) == 4:
                named_dict[key] = ""

def Generate(path):
    
    data_path = EXT_DATA.format(path)
    item_path = EXT_ITEM.format(path)
    script_path = EXT_SCRIPT.format(path)
    
    f = open(item_path)
    item_templ   = f.read()
    f.close()
    
    f = open(script_path)
    script_templ = f.read()
    f.close()
    
    s = ""
    
    with open(data_path) as f:
        reader = csv.DictReader(f)
        for row in reader:
            parseList(row)
            s += item_templ.format(**row)
            s += '\n\n'
    
    f = open(PATH_OUTPUT.format(path), 'w')
    f.write(script_templ.format(body = s))
    f.close()

if __name__ == "__main__":
    for file in FILES:
        Generate(file)