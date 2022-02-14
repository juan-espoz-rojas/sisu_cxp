
float step = 1;
float boxWidth, boxHeight, boxLength;
float zoom = 1.5;
Point p1, p2, p3, p4, p5, p6, p7;

void setup() {
  size(400, 250);
  noStroke();

  p1 = new Point(0, 0);
  p2 = new Point(0, 0);
  p3 = new Point(0, 0);
  p4 = new Point(0, 0);
  p5 = new Point(0, 0);
  p6 = new Point(0, 0);
  p7 = new Point(0, 0);

  boxWidthAdd(30);
  boxLengthAdd(20);
  boxHeightAdd(10);
}

void draw() {
  background(255);

  pushMatrix();
  {
    translate(width/2, height/2);
    caja();
  } 
  popMatrix();
}

void keyPressed() {
  // boxWidth
  if (key == 'a') {
    boxWidthAdd(step);
  }
  if (key == 'z' && boxWidth > step) {
    boxWidthAdd(-step);
  }

  // boxLength
  if (key == 's') {
    boxLengthAdd(step);
  }
  if (key == 'x' && boxLength > step) {
    boxLengthAdd(-step);
  }

  // boxHeight
  if (key == 'd') {
    boxHeightAdd(step);
  }
  if (key == 'c' && boxHeight > step) {
    boxHeightAdd(-step);
  }
}

void boxWidthAdd(float dim) {
  p3.x += cos(PI/6) * dim * zoom;
  p3.y += sin(PI/6) * dim * zoom;
  p6.x += cos(PI/6) * dim * zoom;
  p6.y += sin(PI/6) * dim * zoom;
  p4.x += cos(PI/6) * dim * zoom;
  p4.y += sin(PI/6) * dim * zoom;
  p7.x += cos(PI/6) * dim * zoom;
  p7.y += sin(PI/6) * dim * zoom;
  boxWidth += dim;
}

void boxLengthAdd(float dim) {
  p3.x += cos(PI*5/6) * dim * zoom;
  p3.y += sin(PI*5/6) * dim * zoom;
  p6.x += cos(PI*5/6) * dim * zoom;
  p6.y += sin(PI*5/6) * dim * zoom;
  p2.x += cos(PI*5/6) * dim * zoom;
  p2.y += sin(PI*5/6) * dim * zoom;
  p5.x += cos(PI*5/6) * dim * zoom;
  p5.y += sin(PI*5/6) * dim * zoom;
  boxLength += dim;
}

void boxHeightAdd(float dim) {
  p1.x += cos(-PI/2) * dim * zoom;
  p1.y += sin(-PI/2) * dim * zoom;
  p2.x += cos(-PI/2) * dim * zoom;
  p2.y += sin(-PI/2) * dim * zoom;
  p3.x += cos(-PI/2) * dim * zoom;
  p3.y += sin(-PI/2) * dim * zoom;
  p4.x += cos(-PI/2) * dim * zoom;
  p4.y += sin(-PI/2) * dim * zoom;
  boxHeight += dim;
}

void caja() {
  color c1 = #DDDDDD;
  color c2 = #EFEFEF;
  color c3 = #BCBCBC;

  // cara superior (boxHeight)
  fill(c1);
  beginShape();
  {
    vertex(p1.x, p1.y);
    vertex(p2.x, p2.y);
    vertex(p3.x, p3.y);
    vertex(p4.x, p4.y);
  }
  endShape();

  // cara izquierda (boxLength)
  fill(c2);
  beginShape();
  {
    vertex(p2.x, p2.y);
    vertex(p5.x, p5.y);
    vertex(p6.x, p6.y);
    vertex(p3.x, p3.y);
  }
  endShape();

  // cara derecha (boxWidth)
  fill(c3);
  beginShape();
  {
    vertex(p3.x, p3.y);
    vertex(p6.x, p6.y);
    vertex(p7.x, p7.y);
    vertex(p4.x, p4.y);
  }
  endShape();
}


class Point {
  float x, y;
  Point(float x, float y) {
    this.x = x;
    this.y = y;
  }
}
