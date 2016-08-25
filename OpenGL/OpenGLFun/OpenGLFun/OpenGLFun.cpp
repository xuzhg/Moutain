// OpenGLFun.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <Windows.h>
#include <gl\GL.h>
#include "glut.h"

GLuint texture;
#pragma warning(disable:4996) 
void InitGL()
{
	glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
	glEnable(GL_TEXTURE_2D);
	glTexEnvf(GL_TEXTURE_ENV, GL_TEXTURE_ENV_MODE, GL_MODULATE);
}

void DrawPoint()
{
	glBegin(GL_POINTS);

	glColor3f(1.0f, 1.0f, 1.0f);
	glVertex2f(0.1f, -0.8f);
	glVertex2f(0.7f, -0.8f);
	glVertex2f(0.4f, -0.8f);

	glEnd();
}

void DrawLines()
{
	glBegin(GL_LINES);

	glColor3f(1.0f, 1.0f, 1.0f);
	glVertex2f(0.1f, -0.6f);
	glVertex2f(0.7f, -0.6f);
	glVertex2f(0.7f, -0.6f);
	glVertex2f(0.4f, -0.6f);

	glEnd();
}

void DrawSolidTriangle()
{
	glBegin(GL_TRIANGLES);

	glColor3f(1.0f, 0.0f, 0.0f);
	glVertex2f(0.1f, 0.6f);

	glColor3f(0.0f, 1.0f, 0.0f);
	glVertex2f(0.7f, 0.6f);

	glColor3f(0.0f, 0.0f, 1.0f);
	glVertex2f(0.7f, 0.1f);
	glEnd();
}

void DrawQuad()
{
	glBegin(GL_QUADS);

	glColor3f(0.0f, 1.0f, 0.0f);
	glVertex2f(-0.1f, -0.1f);
	glVertex2f(-0.1f, -0.6f);
	glVertex2f(-0.6f, -0.6f);
	glVertex2f(-0.6f, -0.1f);
	glEnd();
}

void drawTexture()
{
	glBindTexture(GL_TEXTURE_2D, texture);
	glBegin(GL_QUADS);
	glColor3f(1.0f, 1.0f, 1.0f);
	glTexCoord2d(0.0, 0.0); glVertex2d(0.0, 0.0);
	glTexCoord2d(1.0, 0.0); glVertex2d(0.5, 0.0);
	glTexCoord2d(1.0, 1.0); glVertex2d(0.5, 0.5);
	glTexCoord2d(0.0, 1.0); glVertex2d(0.0, 0.5);

	glEnd();
}

void Update()
{
	glClear(GL_COLOR_BUFFER_BIT);
	DrawPoint();
	DrawLines();
	DrawSolidTriangle();
	DrawQuad();
	drawTexture();
	glFlush();
}

bool loadTexture(const char* fileName)
{
	unsigned char header[54];
	unsigned char* data;
	int dataPos;
	int width;
	int height;
	int imageSize;

	FILE* fp;
	fopen_s(&fp, fileName, "rb");
	if (!fp)
		return false;

	if (fread(header, 1, 54, fp) != 54) return false;
	if (header[0] != 'B' || header[1] != 'M') return false;

	dataPos = *(int*)&(header[0X0A]);
	imageSize = *(int*)&(header[0x22]);
	width = *(int*)&(header[0x12]);
	height = *(int*)&(header[0x16]);

	if (imageSize == 0) imageSize = width * height * 3;
	if (dataPos == 0) dataPos = 54;

	data = new unsigned char[imageSize];
	fread(data, 1, imageSize, fp);
	fclose(fp);

	glGenTextures(1, &texture);
	glBindTexture(GL_TEXTURE_2D, texture);
	glTexImage2D(GL_TEXTURE_2D, 0, GL_RGB, width, height, 0, GL_RGB, GL_UNSIGNED_BYTE, data);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_NEAREST);
	return true;
}

int _tmain(int argc, _TCHAR* argv[])
{
	glutCreateWindow("GL Fun");
	glutInitWindowSize(320, 320);
	glutInitWindowPosition(50, 50);
	glutDisplayFunc(Update);
	
	InitGL();

	if (!loadTexture("car.bmp"))
	{
		printf("Cant' load the car.bmp");
		return -1;
	}
	glutMainLoop();
	return 0;
}

