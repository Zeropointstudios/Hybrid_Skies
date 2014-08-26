import re
import sys

def main(argv):
	inFileName = argv[1]
	
	with open(inFileName) as inFile:
		data = inFile.readlines();
		
		curEntity = ""
		entities = {}
		
		for line in data:
			line = line.rstrip();
			
			if (re.match("^%", line)):  # YAML header info
				print (line)
			elif (re.match("^---", line)):
				curEntity = line
			else:
				entities[curEntity] = entities.get(curEntity, "") + line + "\n"

		keys = [key for key in entities]
		keys.sort()
		for key in keys:
			print (key)
			print (entities[key], end="");

if __name__ == "__main__":
    main(sys.argv)
