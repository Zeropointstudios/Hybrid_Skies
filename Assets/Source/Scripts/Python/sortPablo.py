import os
import shutil
import sys

UNITY_PROJECT_DIR = "C:\dev\AncientAliens"
UNITY_SCENES_DIR = UNITY_PROJECT_DIR + "\Assets\Source\_Scenes";
UNITY_PYTHON_DIR = UNITY_PROJECT_DIR + "\Assets\Source\Scripts\Python";
UNITY_FILE = "Pablo.unity"
UNITY_FILE_BACKUP_0 = UNITY_FILE + "_backup_0"
UNITY_FILE_BACKUP_1 = UNITY_FILE + "_backup_1"
UNITY_FILE_BACKUP_2 = UNITY_FILE + "_backup_2"
UNITY_FILE_BACKUP_3 = UNITY_FILE + "_backup_3"
UNITY_FILE_BACKUP_4 = UNITY_FILE + "_backup_4"
UNITY_FILE_SORTED  = UNITY_FILE + "_sorted"

def do(action):
	print(action)
	return os.system(action)

def main(argv):
	os.chdir(UNITY_SCENES_DIR)
	
	try:
		shutil.copy(UNITY_FILE_BACKUP_3, UNITY_FILE_BACKUP_4);
	except:
		pass
		
	try:
		shutil.copy(UNITY_FILE_BACKUP_2, UNITY_FILE_BACKUP_3);
	except:
		pass

	try:
		shutil.copy(UNITY_FILE_BACKUP_1, UNITY_FILE_BACKUP_2);
	except:
		pass

	try:
		shutil.copy(UNITY_FILE_BACKUP_0, UNITY_FILE_BACKUP_1);
	except:
		pass	
	
	shutil.copy(UNITY_FILE, UNITY_FILE_BACKUP_0);
	
	do("python %s\\sortScene.py %s >%s" % (UNITY_PYTHON_DIR, UNITY_FILE, UNITY_FILE_SORTED))

	shutil.copy(UNITY_FILE_SORTED, UNITY_FILE);

if __name__ == "__main__":
    main(sys.argv)
