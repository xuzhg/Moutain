// OpenGLFun.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <Windows.h>
#include <gl\GL.h>
#include "glut.h"

void InitGL()
{
	glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
}

void DrawPoint()
{
	glBegin(GL_POINTS);

	glColor3f(1.0f, 1.0f, 1.0f);
	glVertex2d(0.1f, -0.6f);
	glVertex2d(0.7f, -0.6f);
	glVertex2d(0.4f, -0.6f);

	glEnd();
}

void Update()
{
	glClear(GL_COLOR_BUFFER_BIT);
	DrawPoint();
	glFlush();
}

int _tmain(int argc, _TCHAR* argv[])
{
	glutCreateWindow("GL Fun");
	glutInitWindowSize(320, 320);
	glutInitWindowPosition(50, 50);
	glutDisplayFunc(Update);
	InitGL();
	glutMainLoop();
	return 0;
}

