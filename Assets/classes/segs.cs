using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace segments
{

    class segment
    {
        public Vector2 edge_left, edge_right;
        public bool include_left, include_right;
        public float angle_left, angle_right, dist;


        private void renew()
        {
            this.angle_left = Vector2.Angle(Vector2.right, this.edge_left);
            float angle1 = Vector2.Angle(Vector2.up, this.edge_left);
            this.angle_right = Vector2.Angle(Vector2.right, this.edge_right);
            float angle2 = Vector2.Angle(Vector2.up, this.edge_right);
            if(angle1 < 90)
            {
                this.angle_left = 360 - this.angle_left;
            }
            if(angle2 < 90)
            {
                this.angle_right = 360 - this.angle_right;
            }
            if (angle_right == angle_left)
            {
                if(dist == 0)
                {
                    angle_left += 360;
                }
            }
        }

        

        

        public segment(Vector3 center, Vector3 barrier, Vector3 size) 
        {
            this.include_left = this.include_right = true;
            Vector2 self = barrier - center;
            this.dist = self.magnitude;

            if(self.x - size.x > 0)
            {
                if (self.y - size.y > 0)
                {
                    this.edge_left = new Vector2(self.x - size.x, self.y + size.y);
                    this.edge_right = new Vector2(self.x + size.x, self.y - size.y);

                }
                else if (self.y + size.y < 0)
                {
                    this.edge_left = new Vector2(self.x + size.x, self.y + size.y);
                    this.edge_right = new Vector2(self.x - size.x, self.y - size.y);

                } else
                {
                    this.edge_left = new Vector2(self.x - size.x, self.y + size.y);
                    this.edge_right = new Vector2(self.x - size.x, self.y - size.y);
                }
            } else if(self.x + size.x < 0)
            {
                if (self.y - size.y > 0)
                {
                    this.edge_left = new Vector2(self.x - size.x, self.y - size.y);
                    this.edge_right = new Vector2(self.x + size.x, self.y + size.y);

                }
                else if (self.y + size.y < 0)
                {
                    this.edge_left = new Vector2(self.x + size.x, self.y - size.y);
                    this.edge_right = new Vector2(self.x - size.x, self.y + size.y);

                }
                else
                {
                    this.edge_left = new Vector2(self.x + size.x, self.y - size.y);
                    this.edge_right = new Vector2(self.x + size.x, self.y + size.y);
                }
            } else
            {

                if (self.y - size.y > 0)
                {
                    this.edge_left = new Vector2(self.x - size.x, self.y - size.y);
                    this.edge_right = new Vector2(self.x + size.x, self.y - size.y);

                }
                else if (self.y + size.y < 0)
                {
                    this.edge_left = new Vector2(self.x + size.x, self.y + size.y);
                    this.edge_right = new Vector2(self.x - size.x, self.y + size.y);

                }
                else
                {
                    this.edge_left = new Vector2(self.x - size.x, self.y - size.y);
                    this.edge_right = new Vector2(self.x - size.x, self.y - size.y);
                }
            }
            this.renew();
        }

        public segment()
        {
            this.include_left = this.include_right = false;
            this.dist = 0;
            this.renew();

        }


        public static segment operator -(segment a, segment b)
        {
            segment res = new segment();
            if(a.dist < b.dist)
            {
                return a;
            } else
            {
                if(b.dist == 0)
                {
                    res.include_left = res.include_right = false;
                    res.edge_left = res.edge_right = a.edge_right;
                    res.dist = a.dist;
                    res.renew();
                } else
                {
                    if(b.angle_left > b.angle_right)
                    {
                        if(a.angle_left >= b.angle_left || a.angle_left <= b.angle_right)
                        {
                            if(a.angle_right >= b.angle_left || a.angle_right <= b.angle_right)
                            {
                                res.include_left = res.include_right = false;
                                res.edge_left = res.edge_right = a.edge_right;
                                res.dist = a.dist;
                                res.renew();
                            } else
                            {
                                res.include_left = false;
                                res.edge_left = b.edge_right;
                                res.dist = a.dist;
                                res.renew();
                            }
                        } else
                        {

                            if (a.angle_right >= b.angle_left || a.angle_right <= b.angle_right)
                            {
                                res.include_right = false;
                                res.edge_right = b.edge_left;
                                res.dist = a.dist;
                                res.renew();
                            }
                            else
                            {
                                return a;
                            }
                        }
                    } else
                    {
                        if(a.angle_left >= b.angle_left && a.angle_left <= b.angle_right)
                        {
                            if(a.angle_right >= b.angle_left && a.angle_right <= b.angle_right)
                            {
                                res.include_left = res.include_right = false;
                                res.edge_left = res.edge_right = a.edge_right;
                                res.dist = a.dist;
                                res.renew();
                            }
                            else
                            {
                                res.include_left = false;
                                res.edge_left = b.edge_right;
                                res.dist = a.dist;
                                res.renew();
                            }
                        } else
                        {

                            if (a.angle_right >= b.angle_left && a.angle_right <= b.angle_right)
                            {
                                res.include_right = false;
                                res.edge_right = b.edge_left;
                                res.dist = a.dist;
                                res.renew();
                            }
                            else
                            {
                                return a;
                            }
                        }
                    }
                }
            }


            return res;
        }


        public bool seen(segment[] barriers, segment point)
        {
            segment res;
            res = point;
            for (int i = 0; i < barriers.Length; i++)
            {
                res = res - barriers[i];
            }

            if(res.angle_left == res.angle_right && res.include_left == res.include_right)
            {
                return false;
            }
            return true;
        }



    }
}
