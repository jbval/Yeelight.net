# Yeelight.net
Api pour piloter un dispositif Yeelight (testé sur YLTD001)
Requis :
- Activer l'api local depuis l'application officielle Yeelight
- Saisir l'ip dans appsettings.json 

Méthode et paramètres associés :
| Method value     | Parameters Count |     Param 1      |    Param 2     |         Param 3         |    Param 4    |
| ---------------- | :--------------: | :--------------: | :------------: | :---------------------: | :-----------: |
| get_prop         |      1 ~ N       |        *         |       *        |            *            |       *       |
| set_ct_abx       |        3         |  int (ct_value)  | string(effect) |      int(duration)      |               |
| set_rgb          |        3         |  int(rgb_value)  | string(effect) |      int(duration)      |               |
| set_hsv          |        4         |     int(hue)     |    int(sat)    |     string(effect)      | int(duration) |
| set_bright       |        3         | int(brightness)  | string(effect) |      int(duration)      |               |
| set_power        |        3         |  string(power)   | string(effect) |      int(duration)      |   int(mode)   |
| toggle           |        0         |                  |                |                         |               |
| set_default      |        0         |                  |                |                         |               |
| start_cf         |        3         |    int(count)    |  int(action)   | string(flow_expression) |               |
| stop_cf          |        0         |                  |                |                         |               |
| set_scene        |      3 ~ 4       |  string(class)   |   int(val1)    |        int(val2)        |  *int(val3)   |
| cron_add         |        2         |    int(type)     |   int(value)   |                         |               |
| cron_get         |        1         |    int(type)     |                |                         |               |
| cron_del         |        1         |    int(type)     |                |                         |               |
| set_adjust       |        2         |  string(action)  |  string(prop)  |                         |               |
| set_music        |       1~ 3       |   int(action)    |  string(host)  |        int(port)        |               |
| set_name         |        1         |   string(name)   |                |                         |               |
| bg_set_rgb       |        3         |  int(rgb_value)  | string(effect) |      int(duration)      |               |
| bg_set_hsv       |        4         |     int(hue)     |    int(sat)    |     string(effect)      | int(duration) |
| bg_set_ct_abx    |        3         |  int (ct_value)  | string(effect) |      int(duration)      |               |
| bg_start_cf      |        3         |    int(count)    |  int(action)   | string(flow_expression) |               |
| bg_stop_cf       |        0         |                  |                |                         |               |
| bg_set_scene     |      3 ~ 4       | string   (class) |   int(val1)    |        int(val2)        |  *int(val3)   |
| bg_set_default   |        0         |                  |                |                         |               |
| bg_set_power     |        3         |  string(power)   | string(effect) |      int(duration)      |   int(mode)   |
| bg_set_bright    |        3         | int(brightness)  | string(effect) |      int(duration)      |               |
| bg_set_adjust    |        2         |  string(action)  |  string(prop)  |                         |               |
| bg_toggle        |        0         |                  |                |                         |               |
| dev_toggle       |        0         |                  |                |                         |               |
| adjust_bright    |        2         | int(percentage)  | int(duration)  |                         |               |
| adjust_ct        |        2         | int(percentage)  | int(duration)  |                         |               |
| adjust_color     |        2         | int(percentage)  | int(duration)  |                         |               |
| bg_adjust_bright |        2         | int(percentage)  | int(duration)  |                         |               |
| bg_adjust_ct     |        2         | int(percentage)  | int(duration)  |                         |               |
| bg_adjust_color  |        2         | int(percentage)  | int(duration)  |                         |               |



![.NET](https://github.com/jbval/Yeelight.net/workflows/.NET/badge.svg?branch=master)
