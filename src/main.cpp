#define WIN32_LEAN_AND_MEAN
#define _CRT_SECURE_NO_WARNINGS
#include <Windows.h>
#include <shellapi.h>
#include <iostream>

#include <sqlite3.h>

static int cb_list(void *NotUsed, int argc, char **argv, char **azColName) {
 int i;
	  for (i = 0; i < argc; i++) {
	      printf("%s\n", argv[i]);
		
	}
	return 0;
}

int wmain(int argc, wchar_t *argv[]) {
	if (argc > 1) {
		// Create directory named "data" if doesn't exist
		// any imported documents will be stored here.
		CreateDirectory(L"data", NULL);

		sqlite3 *db;

		// Open list.db, it contains file information
		// Create new list.db if it doesn't exist
		sqlite3_open("list.db", &db);
		sqlite3_exec(db, "CREATE TABLE IF NOT EXISTS `documents` (`name` TEXT NOT NULL, PRIMARY KEY(`name`))", 0, 0, 0);
		
		if (wcscmp(argv[1], L"lists") == 0) {
			sqlite3_exec(db, "SELECT * FROM `documents`", cb_list, 0, 0);
		}
		else if (wcscmp(argv[1], L"import") == 0) {
			if (argc > 2) {
				sqlite3_stmt *stmt;
				sqlite3_prepare_v2(db, "INSERT INTO `documents` VALUES (?)", -1, &stmt, NULL);

				WCHAR path[MAX_PATH];
				GetModuleFileName(NULL, path, MAX_PATH);
		
				LPWSTR dirPtr = wcsrchr(path, L'\\');
				dirPtr[1] = '\0';

				for (int i = 2; i < argc; i++) {
					WCHAR namePath[MAX_PATH] = L"";
					WCHAR destPath[MAX_PATH] = L"";
				
					wcscat(destPath, path);
					wcscat(destPath, L"data\\");

					LPWSTR namePtr = wcsrchr(argv[i], L'\\');
					if (namePtr == nullptr) {
						goto err;
					}
					wcscat(namePath, namePtr + 1);
					wcscat(destPath, namePath);

					if (CopyFile(argv[i], destPath, TRUE) != 0) {
						CHAR c[MAX_PATH] = "";
						wcstombs(c, namePath, MAX_PATH);

						sqlite3_bind_text(stmt, 1, c, -1, SQLITE_STATIC);
						sqlite3_step(stmt);
					}
					else {
						err:
						std::cout << "list: Couldn't import file, something went wrong.";
					}
				}
			}
			else {
				std::cout << "list import [<target>]";
			}
		}

		sqlite3_close(db);
	}
	return 0;
}